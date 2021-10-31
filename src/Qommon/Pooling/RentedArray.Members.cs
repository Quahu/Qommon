using System;
using System.Collections;
using System.Collections.Generic;

namespace Qommon.Pooling
{
    public readonly partial struct RentedArray<T>
    {
        public int Length => _segment.Count;

        public T this[int index]
        {
            get => _segment[index];
            set => _segment[index] = value;
        }

        public RentedArray<T> this[Range range] => new(_segment[range], _pool, _clearArray);

        public void CopyTo(T[] array)
            => _segment.CopyTo(array);

        public void CopyTo(Span<T> destination)
            => _segment.AsSpan().CopyTo(destination);

        public void CopyTo(T[] array, int arrayIndex)
            => _segment.CopyTo(array, arrayIndex);

        public ArraySegment<T>.Enumerator GetEnumerator()
            => _segment.GetEnumerator();

        int ICollection<T>.Count => _segment.Count;

        int IReadOnlyCollection<T>.Count => _segment.Count;

        bool ICollection<T>.IsReadOnly => false;

        int IList<T>.IndexOf(T item)
            => Array.IndexOf(_segment.Array, item, _segment.Offset, _segment.Count);

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
