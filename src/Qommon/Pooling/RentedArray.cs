using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Qommon.Pooling
{
    /// <summary>
    ///     Represents an array rented from an <see cref="ArrayPool{T}"/> that will be returned to it on disposal.
    ///     Does not perform any validation checks on the underlying array nor on the pool.
    /// </summary>
    /// <typeparam name="T"> The type of the elements in the array. </typeparam>
    public readonly struct RentedArray<T> : IList<T>, IReadOnlyList<T>, IDisposable
    {
        public int Length => _segment.Count;

        public T this[int index]
        {
            get => _segment[index];
            set => _segment[index] = value;
        }

        public RentedArray<T> this[Range range] => new(_segment[range], _pool);

        private readonly ArraySegment<T> _segment;
        private readonly ArrayPool<T> _pool;

        public RentedArray(ArraySegment<T> segment, ArrayPool<T> pool)
        {
            Guard.IsNotNull(pool);

            _segment = segment;
            _pool = pool;
        }

        public void CopyTo(T[] array)
            => _segment.CopyTo(array);

        public void CopyTo(Span<T> destination)
            => _segment.AsSpan().CopyTo(destination);

        public void CopyTo(T[] array, int arrayIndex)
            => _segment.CopyTo(array, arrayIndex);

        public ArraySegment<T>.Enumerator GetEnumerator()
            => _segment.GetEnumerator();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose()
        {
            if (_segment.Array != null)
                _pool.Return(_segment.Array);
        }

        public ArraySegment<T> AsArraySegment()
            => _segment;

        public Memory<T> AsMemory()
            => _segment;

        public Memory<T> AsMemory(int start)
            => _segment.AsMemory(start);

        public Span<T> AsSpan()
            => _segment;

        public static implicit operator ArraySegment<T>(RentedArray<T> value)
            => value._segment;

        public static implicit operator Memory<T>(RentedArray<T> value)
            => value._segment;

        public static implicit operator ReadOnlyMemory<T>(RentedArray<T> value)
            => value._segment;

        public static implicit operator Span<T>(RentedArray<T> value)
            => value._segment;

        public static implicit operator ReadOnlySpan<T>(RentedArray<T> value)
            => value._segment;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RentedArray<T> Rent(int length)
            => Rent(length, ArrayPool<T>.Shared);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RentedArray<T> Rent(int length, ArrayPool<T> pool)
        {
            Guard.IsNotNull(pool);
            return new(new(pool.Rent(length), 0, length), pool);
        }

        int ICollection<T>.Count => _segment.Count;

        int IReadOnlyCollection<T>.Count => _segment.Count;

        bool ICollection<T>.IsReadOnly => false;

        int IList<T>.IndexOf(T item)
            => throw new NotSupportedException();

        void IList<T>.Insert(int index, T item)
            => throw new NotSupportedException();

        void IList<T>.RemoveAt(int index)
            => throw new NotSupportedException();

        void ICollection<T>.Add(T item)
            => throw new NotSupportedException();

        void ICollection<T>.Clear()
            => throw new NotSupportedException();

        bool ICollection<T>.Contains(T item)
            => throw new NotSupportedException();

        bool ICollection<T>.Remove(T item)
            => throw new NotSupportedException();

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
            => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
