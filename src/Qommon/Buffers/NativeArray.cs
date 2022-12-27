using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace Qommon.Buffers;

/// <summary>
///     Represents an array over unmanaged memory.
/// </summary>
/// <typeparam name="T"> The unmanaged type of elements. </typeparam>
public readonly struct NativeArray<T> : IList<T>, IList, IReadOnlyList<T>, IDisposable
    where T : unmanaged
{
    /// <summary>
    ///     Gets an empty <see cref="NativeArray{T}"/>.
    /// </summary>
    public static NativeArray<T> Empty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => default;
    }

    /// <summary>
    ///     Gets the pointer to the memory of this array.
    /// </summary>
    public IntPtr Pointer
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _ptr;
    }

    /// <summary>
    ///     Gets the length of this array.
    /// </summary>
    public int Length
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _length;
    }

    /// <summary>
    ///     Gets a span with the items of this array.
    /// </summary>
    public unsafe Span<T> Span
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            if (_length == 0)
                return default;

            return new((void*) _ptr, _length);
        }
    }

    /// <summary>
    ///     Gets or sets the item at the given index.
    /// </summary>
    /// <param name="index"> The index of the item. </param>
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Span[index];
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => Span[index] = value;
    }

    private readonly IntPtr _ptr;
    private readonly int _length;

    /// <summary>
    ///     Instantiates a new <see cref="NativeArray{T}"/> with the given length.
    /// </summary>
    /// <param name="length"> The length of the array. </param>
    /// <param name="zeroed"> Whether the memory should be zeroed. </param>
    public unsafe NativeArray(nuint length, bool zeroed = false)
    {
        var elementSize = (nuint) sizeof(T);
        _ptr = (IntPtr) (zeroed
            ? NativeMemory.AllocZeroed(length, elementSize)
            : NativeMemory.Alloc(length, elementSize));

        _length = (int) length;
    }

    /// <summary>
    ///     Instantiates a new <see cref="NativeArray{T}"/> with the given pointer and length.
    /// </summary>
    /// <param name="ptr"> The pointer to the memory. </param>
    /// <param name="length"> The length of the array. </param>
    public NativeArray(IntPtr ptr, int length)
    {
        _ptr = ptr;
        _length = length;
    }

    /// <summary>
    ///     Reinterprets this array as the given type.
    /// </summary>
    /// <typeparam name="TTarget"> The target type of the items. </typeparam>
    /// <returns>
    ///     The reinterpreted array.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public NativeArray<TTarget> Cast<TTarget>()
        where TTarget : unmanaged
    {
        return new NativeArray<TTarget>(_ptr, _length);
    }

    /// <summary>
    ///     Copies the contents of this array to a new array.
    /// </summary>
    /// <returns>
    ///     The new array.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T[] ToArray()
    {
        return Span.ToArray();
    }

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public unsafe void Dispose()
    {
        var ptr = Interlocked.Exchange(ref Unsafe.AsRef(in _ptr), IntPtr.Zero);
        NativeMemory.Free((void*) ptr);
    }

    /// <summary>
    ///     Represents the enumerator for <see cref="NativeArray{T}"/>.
    /// </summary>
    public struct Enumerator : IEnumerator<T>
    {
        /// <inheritdoc />
        public readonly T Current
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _array.Span[_index];
        }

        /// <inheritdoc />
        readonly object IEnumerator.Current
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Current;
        }

        private readonly NativeArray<T> _array;
        private int _index;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal Enumerator(NativeArray<T> array)
        {
            _array = array;
            _index = -1;
        }

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
        {
            var index = _index + 1;
            if (index < _array._length)
            {
                _index = index;
                return true;
            }

            return false;
        }

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Reset()
        {
            _index = -1;
        }

        /// <inheritdoc />
        readonly void IDisposable.Dispose()
        { }
    }

    /// <summary>
    ///     Gets an enumerator that iterates through this <see cref="NativeArray{T}"/>.
    /// </summary>
    /// <returns>
    ///     The enumerator.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Enumerator GetEnumerator()
    {
        return new Enumerator(this);
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return new Enumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new Enumerator(this);
    }

    /// <summary>
    ///     Implicitly converts this <see cref="NativeArray{T}"/> to a span.
    /// </summary>
    /// <param name="array"> The array. </param>
    /// <returns>
    ///     A span of the array.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Span<T>(NativeArray<T> array)
        => array.Span;

    /// <summary>
    ///     Implicitly converts this <see cref="NativeArray{T}"/> to a span.
    /// </summary>
    /// <param name="array"> The array. </param>
    /// <returns>
    ///     A span of the array.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator ReadOnlySpan<T>(NativeArray<T> array)
        => array.Span;

    int ICollection<T>.Count => _length;

    bool ICollection<T>.IsReadOnly => true;

    int IReadOnlyCollection<T>.Count => _length;

    int IList<T>.IndexOf(T item)
    {
        throw new NotSupportedException();
    }

    void IList<T>.Insert(int index, T item)
    {
        throw new NotSupportedException();
    }

    void IList<T>.RemoveAt(int index)
    {
        throw new NotSupportedException();
    }

    void ICollection<T>.Add(T item)
    {
        throw new NotSupportedException();
    }

    bool ICollection<T>.Contains(T item)
    {
        throw new NotSupportedException();
    }

    void ICollection<T>.Clear()
    {
        Span.Clear();
    }

    void ICollection<T>.CopyTo(T[] array, int arrayIndex)
    {
        Span.CopyTo(array.AsSpan(arrayIndex));
    }

    bool ICollection<T>.Remove(T item)
    {
        throw new NotSupportedException();
    }

    object? IList.this[int index]
    {
        get => this[index];
        set => this[index] = (T) value!;
    }

    bool IList.IsReadOnly => true;

    bool IList.IsFixedSize => true;

    int ICollection.Count => _length;

    bool ICollection.IsSynchronized => false;

    object ICollection.SyncRoot => this;

    int IList.Add(object? value)
    {
        throw new NotSupportedException();
    }

    bool IList.Contains(object? value)
    {
        throw new NotSupportedException();
    }

    void IList.Clear()
    {
        Span.Clear();
    }

    void ICollection.CopyTo(Array array, int index)
    {
        var typedArray = Guard.IsAssignableToType<T[]>(array);
        Span.CopyTo(typedArray.AsSpan(index));
    }

    int IList.IndexOf(object? value)
    {
        throw new NotSupportedException();
    }

    void IList.Insert(int index, object? value)
    {
        throw new NotSupportedException();
    }

    void IList.Remove(object? value)
    {
        throw new NotSupportedException();
    }

    void IList.RemoveAt(int index)
    {
        throw new NotSupportedException();
    }
}
