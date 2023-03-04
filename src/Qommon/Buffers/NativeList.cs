using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace Qommon.Buffers;

/// <summary>
///     Represents a list that uses unmanaged memory.
/// </summary>
/// <typeparam name="T"> The unmanaged type of elements. </typeparam>
/// <remarks>
///     When you are done working with the list,
///     make sure to call <see cref="Free"/> (see the remarks) to free
///     any unmanaged memory that was possibly allocated
///     by the list and prevent leaking memory.
/// </remarks>
[DebuggerTypeProxy(typeof(NativeListDebuggerProxy<>))]
[DebuggerDisplay("Count = {Count}")]
public struct NativeList<T> : IList<T>, IList, IReadOnlyList<T>,
    IEquatable<NativeList<T>>
    where T : unmanaged
{
    /// <summary>
    ///     Gets an empty <see cref="NativeList{T}"/>.
    /// </summary>
    public static NativeList<T> Empty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => default;
    }

    /// <summary>
    ///     Gets the pointer to the allocated memory of this list.
    /// </summary>
    public readonly IntPtr Pointer
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _ptr;
    }

    /// <summary>
    ///     Gets the amount of items this list can contain.
    /// </summary>
    public int Capacity
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get => _capacity;
        set
        {
            Guard.IsGreaterThanOrEqualTo(value, _size);

            if (value == _capacity)
                return;

            if (value == 0)
            {
                _capacity = 0;
                _size = 0;
                return;
            }

            if (value > _capacity || _freePtr)
            {
                if (_freePtr)
                {
                    // We own the currently allocated memory - realloc.
                    unsafe
                    {
                        var elementSize = (nuint) sizeof(T);
                        var newByteCount = NativeUtilities.GetByteCount((nuint) value, elementSize);
                        _ptr = (IntPtr) NativeMemory.Realloc((void*) _ptr, newByteCount);
                        _capacity = value;
                    }
                }
                else
                {
                    // We don't own the currently allocated memory - alloc.
                    var newList = new NativeList<T>((nuint) value);
                    newList._size = _size;

                    // Copy the items over.
                    Span.CopyTo(newList.WorkingSpan);

                    this = newList;
                }
            }
            else
            {
                _capacity = value;
            }
        }
    }

    /// <summary>
    ///     Gets the amount of items in this list.
    /// </summary>
    public readonly int Count
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _size;
    }

    /// <summary>
    ///     Gets a span with the items of this list.
    /// </summary>
    public readonly unsafe Span<T> Span
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            if (_size == 0)
                return default;

            return new((void*) _ptr, _size);
        }
    }

    /// <summary>
    ///     Gets a span that represents the current buffer of this list.
    /// </summary>
    private unsafe Span<T> WorkingSpan
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            if (_capacity == 0)
                return default;

            return new((void*) _ptr, _capacity);
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

    private const int DefaultCapacityInBytes = 32;

    private IntPtr _ptr;
    private int _capacity;
    private int _size;
    private readonly bool _freePtr;

    /// <summary>
    ///     Instantiates a new <see cref="NativeList{T}"/> with the specified capacity.
    /// </summary>
    /// <param name="capacity"> The capacity of the list. </param>
    public unsafe NativeList(nuint capacity)
    {
        var elementSize = (nuint) sizeof(T);
        _ptr = (IntPtr) NativeMemory.Alloc(capacity, elementSize);
        _capacity = (int) capacity;
        _freePtr = true;
    }

    /// <summary>
    ///     Instantiates a new <see cref="NativeList{T}"/> with the specified pointer and length.
    /// </summary>
    /// <remarks>
    ///     The memory specified by the pointer is not deallocated by <see cref="Free"/> (see the remarks).
    /// </remarks>
    /// <param name="ptr"> The pointer to the memory. </param>
    /// <param name="capacity"> The length of the list. </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public NativeList(IntPtr ptr, int capacity)
    {
        Guard.IsNotEqualTo(ptr, IntPtr.Zero);

        _ptr = ptr;
        _capacity = capacity;
        _freePtr = false;
    }

    /// <inheritdoc cref="NativeList{T}(IntPtr,int)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public unsafe NativeList(T* ptr, int capacity)
        : this((IntPtr) ptr, capacity)
    { }

    /// <summary>
    ///     Ensures this list can fit <paramref name="capacity"/> items in total.
    /// </summary>
    /// <param name="capacity"> The expected capacity. </param>
    /// <returns>
    ///     The new capacity.
    /// </returns>
    public int EnsureCapacity(int capacity)
    {
        Guard.IsNotNegative(capacity);

        if (_capacity < capacity)
        {
            Grow(capacity);
        }

        return _capacity;
    }

    private void Grow(int capacity)
    {
        int newcapacity;
        if (_capacity == 0)
        {
            unsafe
            {
                newcapacity = DefaultCapacityInBytes / sizeof(T);
            }
        }
        else
        {
            newcapacity = _capacity * 2;
        }

        if ((uint) newcapacity > int.MaxValue)
            newcapacity = int.MaxValue;

        if (newcapacity < capacity)
            newcapacity = capacity;

        Capacity = newcapacity;
    }

    /// <summary>
    ///     Reinterprets this list as the given type.
    /// </summary>
    /// <typeparam name="TTarget"> The target type of the items. </typeparam>
    /// <returns>
    ///     The reinterpreted list.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly unsafe NativeList<TTarget> Cast<TTarget>()
        where TTarget : unmanaged
    {
        var oldCapacity = _capacity;
        var oldSize = sizeof(T);
        var newSize = sizeof(TTarget);
        var newCapacity = oldCapacity * oldSize / newSize;
        return new NativeList<TTarget>(_ptr, newCapacity)
        {
            _size = _size * oldSize / newSize
        };
    }

    /// <summary>
    ///     Adds the specified item to this list.
    /// </summary>
    /// <param name="item"> The item to add. </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Add(T item)
    {
        var size = _size;
        if ((uint) size < (uint) _capacity)
        {
            _size = size + 1;
            WorkingSpan[size] = item;
        }
        else
        {
            AddWithResize(item);
        }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private void AddWithResize(T item)
    {
        var size = _size;
        Grow(size + 1);
        _size = size + 1;
        WorkingSpan[size] = item;
    }

    /// <summary>
    ///     Adds the specified items to this list.
    /// </summary>
    /// <param name="items"> The items to add. </param>
    public void AddRange(ReadOnlySpan<T> items)
    {
        if (_capacity - _size < items.Length)
        {
            Grow(checked(_size + items.Length));
        }

        items.CopyTo(WorkingSpan[_size..]);
        _size += items.Length;
    }

    /// <summary>
    ///     Adds the specified items to this list.
    /// </summary>
    /// <param name="items"> The items to add. </param>
    public void AddRange(IEnumerable<T> items)
    {
        Guard.IsNotNull(items);

        if (items is ICollection<T> collection)
        {
            var count = collection.Count;
            if (count > 0)
            {
                if (_capacity - _size < count)
                {
                    Grow(checked(_size + count));
                }

                if (collection is T[] array)
                {
                    array.CopyTo(WorkingSpan[_size..]);
                }
                else if (collection is List<T> stdList)
                {
                    CollectionsMarshal.AsSpan(stdList).CopyTo(WorkingSpan[_size..]);
                }
                else
                {
                    var workingSpan = WorkingSpan[_size..];
                    if (collection is IList<T> list)
                    {
                        var listCount = list.Count;
                        for (var i = 0; i < listCount; i++)
                        {
                            workingSpan[i] = list[i];
                        }
                    }
                    else
                    {
                        var index = 0;
                        foreach (var item in collection)
                        {
                            workingSpan[index++] = item;
                        }
                    }
                }

                _size += count;
            }
        }
        else
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }
    }

    /// <inheritdoc cref="ICollection{T}.Clear"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Clear()
    {
        _size = 0;
    }

    /// <inheritdoc cref="IList{T}.IndexOf"/>
    public readonly int IndexOf(T item)
    {
        var comparer = EqualityComparer<T>.Default;
        var span = Span;
        for (var i = 0; i < span.Length; i++)
        {
            var listItem = span[i];
            if (comparer.Equals(listItem, item))
                return i;
        }

        return -1;
    }

    /// <inheritdoc cref="IList{T}.Insert"/>
    public void Insert(int index, T item)
    {
        if ((uint) index > (uint) _size)
        {
            Throw.ArgumentOutOfRangeException(nameof(index));
        }

        if (_size == _capacity)
        {
            Grow(_size + 1);
        }

        if (index < _size)
        {
            Span[index..].CopyTo(WorkingSpan[(index + 1)..]);
        }

        WorkingSpan[index] = item;
        _size++;
    }

    /// <inheritdoc cref="IList{T}.RemoveAt"/>
    public void RemoveAt(int index)
    {
        if ((uint) index >= (uint) _size)
        {
            Throw.ArgumentOutOfRangeException(nameof(index));
        }

        _size--;
        if (index < _size)
        {
            var workingSpan = WorkingSpan;
            var count = _size - index;
            workingSpan.Slice(index + 1, count).CopyTo(workingSpan.Slice(index, count));
        }
    }

    /// <inheritdoc cref="ICollection{T}.Contains"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool Contains(T item)
    {
        return IndexOf(item) != -1;
    }

    /// <inheritdoc cref="ICollection{T}.CopyTo"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void CopyTo(T[] array, int arrayIndex)
    {
        Span.CopyTo(array.AsSpan(arrayIndex));
    }

    /// <inheritdoc cref="ICollection{T}.Remove"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Remove(T item)
    {
        var index = IndexOf(item);
        if (index >= 0)
        {
            RemoveAt(index);
            return true;
        }

        return false;
    }

    /// <summary>
    ///     Trims the excess capacity of this list.
    /// </summary>
    public void TrimExcess()
    {
        var threshold = (int) (_capacity * 0.9);
        if (_size < threshold)
        {
            Capacity = _size;
        }
    }

    /// <summary>
    ///     Copies the items of this list to a managed array.
    /// </summary>
    /// <returns>
    ///     The managed array containing the copied items.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly T[] ToArray()
    {
        return Span.ToArray();
    }

    /// <inheritdoc/>
    public readonly override string ToString()
    {
        return $"Qommon.Buffers.NativeList<{typeof(T).Name}>[{_capacity}]";
    }

    /// <inheritdoc/>
    public readonly bool Equals(NativeList<T> other)
    {
        return _ptr == other._ptr && _capacity == other._capacity && _size == other._size;
    }

    /// <inheritdoc/>
    public readonly override bool Equals(object? obj)
    {
        return obj is NativeList<T> other && Equals(other);
    }

    /// <inheritdoc/>
    public readonly override int GetHashCode()
    {
        return _ptr.GetHashCode();
    }

    /// <summary>
    ///     Frees the memory allocated by this list.
    /// </summary>
    /// <remarks>
    ///     This does not free the memory that was specified via the
    ///     <see cref="NativeList{T}(IntPtr, int)"/> and <see cref="NativeList{T}(T*, int)"/> constructors.
    ///     You must free that memory yourself.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public unsafe void Free()
    {
        var ptr = Interlocked.Exchange(ref Unsafe.AsRef(in _ptr), IntPtr.Zero);
        if (_freePtr)
        {
            NativeMemory.Free((void*) ptr);
        }
    }

    /// <summary>
    ///     Represents the enumerator for <see cref="NativeList{T}"/>.
    /// </summary>
    public struct Enumerator : IEnumerator<T>
    {
        /// <inheritdoc/>
        public readonly T Current
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _list.Span[_index];
        }

        /// <inheritdoc/>
        readonly object IEnumerator.Current
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Current;
        }

        private readonly NativeList<T> _list;
        private int _index;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal Enumerator(NativeList<T> list)
        {
            _list = list;
            _index = -1;
        }

        /// <inheritdoc/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
        {
            var index = _index + 1;
            if (index < _list._size)
            {
                _index = index;
                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Reset()
        {
            _index = -1;
        }

        /// <inheritdoc/>
        readonly void IDisposable.Dispose()
        { }
    }

    /// <summary>
    ///     Gets an enumerator that iterates through this <see cref="NativeList{T}"/>.
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
    ///     Implicitly converts this <see cref="NativeList{T}"/> to a span.
    /// </summary>
    /// <param name="list"> The list. </param>
    /// <returns>
    ///     A span of the list.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator Span<T>(NativeList<T> list)
    {
        return list.Span;
    }

    /// <summary>
    ///     Implicitly converts this <see cref="NativeList{T}"/> to a span.
    /// </summary>
    /// <param name="list"> The list. </param>
    /// <returns>
    ///     A span of the list.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator ReadOnlySpan<T>(NativeList<T> list)
    {
        return list.Span;
    }

    public static bool operator ==(NativeList<T> left, NativeList<T> right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(NativeList<T> left, NativeList<T> right)
    {
        return !left.Equals(right);
    }

    bool ICollection<T>.IsReadOnly => true;

    int IReadOnlyCollection<T>.Count => _capacity;

    object? IList.this[int index]
    {
        get => this[index];
        set => this[index] = (T) value!;
    }

    bool IList.IsReadOnly => true;

    bool IList.IsFixedSize => true;

    bool ICollection.IsSynchronized => false;

    object ICollection.SyncRoot => this;

    int IList.Add(object? value)
    {
        Add((T) value!);
        return _size - 1;
    }

    bool IList.Contains(object? value)
    {
        return Contains((T) value!);
    }

    void ICollection.CopyTo(Array list, int index)
    {
        var typedArray = Guard.IsAssignableToType<T[]>(list);
        CopyTo(typedArray, index);
    }

    int IList.IndexOf(object? value)
    {
        return IndexOf((T) value!);
    }

    void IList.Insert(int index, object? value)
    {
        Insert(index, (T) value!);
    }

    void IList.Remove(object? value)
    {
        Remove((T) value!);
    }
}
