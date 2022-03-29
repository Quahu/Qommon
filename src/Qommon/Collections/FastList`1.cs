// Adapted from the stdlib, original copyright

#if NET6_0_OR_GREATER
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Qommon.Collections
{
    /// <summary>
    ///     Represents a type equivalent to <see cref="List{T}"/>, but with less checks
    ///     and easier access to the underlying array.
    /// </summary>
    /// <typeparam name="T"> The type of the items. </typeparam>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DebuggerDisplay("Count = {Count}")]
    public class FastList<T> : IList<T>, IList, IReadOnlyList<T>
    {
        private const int DefaultCapacity = 4;

        public int Capacity
        {
            get => _items.Length;
            set
            {
                Guard.IsNotNegative(value);

                if (value == _items.Length)
                    return;

                if (value == 0)
                {
                    _items = Array.Empty<T>();
                    return;
                }

                var newItems = new T[value];
                if (_size > 0)
                    Array.Copy(_items, newItems, _size);

                _items = newItems;
            }
        }

        public int Count => _size;

        public T this[int index]
        {
            get
            {
                Guard.IsLessThan(index, _size);

                return _items[index];
            }

            set
            {
                Guard.IsLessThan(index, _size);

                _items[index] = value;
            }
        }

        private T[] _items;
        private int _size;

        public FastList()
        {
            _items = Array.Empty<T>();
        }

        public FastList(int capacity)
        {
            Guard.IsNotNegative(capacity);

            _items = capacity == 0
                ? Array.Empty<T>()
                : new T[capacity];
        }

        public FastList(IEnumerable<T> enumerable)
        {
            Guard.IsNotNull(enumerable);

            if (enumerable is ICollection<T> collection)
            {
                var count = collection.Count;
                if (count == 0)
                {
                    _items = Array.Empty<T>();
                }
                else
                {
                    _items = new T[count];
                    collection.CopyTo(_items, 0);
                    _size = count;
                }
            }
            else
            {
                _items = Array.Empty<T>();
                using (var enumerator = enumerable.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        Add(enumerator.Current);
                    }
                }
            }
        }

        public ArraySegment<T> AsArraySegment()
            => new(_items, 0, _size);

        public Span<T> AsSpan()
            => new(_items, 0, _size);

        public Memory<T> AsMemory()
            => new(_items, 0, _size);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(T item)
        {
            var array = _items;
            var size = _size;
            if ((uint) size < (uint) array.Length)
            {
                _size = size + 1;
                array[size] = item;
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
            _items[size] = item;
        }

        public void AddRange(IEnumerable<T> enumerable)
            => InsertRange(_size, enumerable);

        public int BinarySearch(int index, int count, T item, IComparer<T>? comparer)
        {
            Guard.IsNotNegative(index);
            Guard.IsNotNegative(count);
            Guard.IsLessThanOrEqualTo(count, _size - index);

            return Array.BinarySearch(_items, index, count, item, comparer);
        }

        public int BinarySearch(T item)
            => BinarySearch(0, Count, item, null);

        public int BinarySearch(T item, IComparer<T>? comparer)
            => BinarySearch(0, Count, item, comparer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear()
        {
            if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
            {
                var size = _size;
                _size = 0;
                if (size > 0)
                    Array.Clear(_items, 0, size);
            }
            else
            {
                _size = 0;
            }
        }

        public bool Contains(T item)
        {
            return _size != 0 && IndexOf(item) >= 0;
        }

        public void CopyTo(T[] array)
            => CopyTo(array, 0);

        public void CopyTo(int index, T[] array, int arrayIndex, int count)
        {
            Guard.IsLessThanOrEqualTo(count, _size - index);

            Array.Copy(_items, index, array, arrayIndex, count);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(_items, 0, array, arrayIndex, _size);
        }

        public int EnsureCapacity(int capacity)
        {
            Guard.IsNotNegative(capacity);

            if (_items.Length < capacity)
                Grow(capacity);

            return _items.Length;
        }

        private void Grow(int capacity)
        {
            var newcapacity = _items.Length == 0
                ? DefaultCapacity
                : _items.Length * 2;

            if ((uint) newcapacity > Array.MaxLength)
                newcapacity = Array.MaxLength;

            if (newcapacity < capacity)
                newcapacity = capacity;

            Capacity = newcapacity;
        }

        public Enumerator GetEnumerator()
            => new(this);

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
            => new Enumerator(this);

        IEnumerator IEnumerable.GetEnumerator()
            => new Enumerator(this);

        public int IndexOf(T item)
            => Array.IndexOf(_items, item, 0, _size);

        public int IndexOf(T item, int index)
        {
            Guard.IsLessThanOrEqualTo(index, _size);

            return Array.IndexOf(_items, item, index, _size - index);
        }

        public int IndexOf(T item, int index, int count)
        {
            Guard.IsLessThanOrEqualTo(index, _size);
            Guard.IsGreaterThanOrEqualTo(count, 0);
            Guard.IsLessThanOrEqualTo(index, _size - count);

            return Array.IndexOf(_items, item, index, count);
        }

        public void Insert(int index, T item)
        {
            Guard.IsLessThanOrEqualTo(index, _size);

            if (_size == _items.Length)
                Grow(_size + 1);

            if (index < _size)
                Array.Copy(_items, index, _items, index + 1, _size - index);

            _items[index] = item;
            _size++;
        }

        public void InsertRange(int index, IEnumerable<T> enumerable)
        {
            Guard.IsNotNull(enumerable);
            Guard.IsLessThanOrEqualTo(index, _size);

            if (enumerable is ICollection<T> collection)
            {
                var count = collection.Count;
                if (count > 0)
                {
                    if (_items.Length - _size < count)
                        Grow(_size + count);

                    if (index < _size)
                        Array.Copy(_items, index, _items, index + count, _size - index);

                    if (this == collection)
                    {
                        Array.Copy(_items, 0, _items, index, index);
                        Array.Copy(_items, index + count, _items, index * 2, _size - index);
                    }
                    else
                    {
                        collection.CopyTo(_items, index);
                    }

                    _size += count;
                }
            }
            else
            {
                using (var enumerator = enumerable.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        Insert(index++, enumerator.Current);
                    }
                }
            }
        }

        public int LastIndexOf(T item)
        {
            if (_size == 0)
                return -1;

            return LastIndexOf(item, _size - 1, _size);
        }

        public int LastIndexOf(T item, int index)
        {
            Guard.IsLessThan(index, _size);

            return LastIndexOf(item, index, index + 1);
        }

        public int LastIndexOf(T item, int index, int count)
        {
            Guard.IsNotNegative(index);
            Guard.IsNotNegative(count);

            if (_size == 0)
                return -1;

            Guard.IsLessThan(index, _size);
            Guard.IsLessThanOrEqualTo(count, index + 1);

            return Array.LastIndexOf(_items, item, index, count);
        }

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

        public void RemoveAt(int index)
        {
            Guard.IsGreaterThanOrEqualTo(index, _size);

            _size--;
            if (index < _size)
                Array.Copy(_items, index + 1, _items, index, _size - index);

            if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
                _items[_size] = default!;
        }

        public void RemoveRange(int index, int count)
        {
            Guard.IsNotNegative(index);
            Guard.IsNotNegative(count);
            Guard.IsLessThanOrEqualTo(count, _size - index);

            if (count > 0)
            {
                _size -= count;
                if (index < _size)
                    Array.Copy(_items, index + count, _items, index, _size - index);

                if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
                    Array.Clear(_items, _size, count);
            }
        }

        public void Reverse()
            => Reverse(0, _size);

        public void Reverse(int index, int count)
        {
            Guard.IsNotNegative(index);
            Guard.IsNotNegative(count);
            Guard.IsLessThanOrEqualTo(count, _size - index);

            if (count > 1)
                Array.Reverse(_items, index, count);
        }

        public void Sort()
            => Sort(0, Count, null);

        public void Sort(IComparer<T>? comparer)
            => Sort(0, Count, comparer);

        public void Sort(int index, int count, IComparer<T>? comparer)
        {
            Guard.IsNotNegative(index);
            Guard.IsNotNegative(count);
            Guard.IsLessThanOrEqualTo(count, _size - index);

            if (count > 1)
                Array.Sort(_items, index, count, comparer);
        }

        public void Sort(Comparison<T> comparison)
        {
            Guard.IsNotNull(comparison);

            if (_size > 1)
                new Span<T>(_items, 0, _size).Sort(comparison);
        }

        public T[] ToArray()
        {
            if (_size == 0)
                return Array.Empty<T>();

            var array = new T[_size];
            Array.Copy(_items, array, _size);
            return array;
        }

        public void TrimExcess()
        {
            var threshold = (int) (_items.Length * 0.9);
            if (_size < threshold)
                Capacity = _size;
        }

        public struct Enumerator : IEnumerator<T>
        {
            public T Current => _current!;

            object? IEnumerator.Current => _current;

            private readonly FastList<T> _list;
            private int _index;
            private T? _current;

            internal Enumerator(FastList<T> list)
            {
                _list = list;
                _index = 0;
                _current = default;
            }

            public bool MoveNext()
            {
                var localList = _list;
                if ((uint) _index < (uint) localList._size)
                {
                    _current = localList._items[_index];
                    _index++;
                    return true;
                }

                return MoveNextRare();
            }

            private bool MoveNextRare()
            {
                _index = _list._size + 1;
                _current = default;
                return false;
            }

            void IEnumerator.Reset()
            {
                _index = 0;
                _current = default;
            }

            public void Dispose()
            { }
        }

        bool ICollection<T>.IsReadOnly => false;

        bool IList.IsReadOnly => false;

        bool IList.IsFixedSize => false;

        object ICollection.SyncRoot => this;

        bool ICollection.IsSynchronized => false;

        object? IList.this[int index]
        {
            get => this[index];
            set => this[index] = (T) value!;
        }

        private static bool IsCompatibleObject(object? value)
            => value is T || value == null && default(T) == null;

        int IList.Add(object? item)
        {
            Add((T) item!);
            return _size - 1;
        }

        void ICollection.CopyTo(Array array, int arrayIndex)
        {
            Guard.IsNotNull(array);
            Guard.IsNotMultiDimensional(array);

            Array.Copy(_items, 0, array!, arrayIndex, _size);
        }

        bool IList.Contains(object? item)
        {
            if (IsCompatibleObject(item))
                return Contains((T) item!);

            return false;
        }

        int IList.IndexOf(object? item)
        {
            if (IsCompatibleObject(item))
                return IndexOf((T) item!);

            return -1;
        }

        void IList.Insert(int index, object? item)
        {
            Insert(index, (T) item!);
        }

        void IList.Remove(object? item)
        {
            if (!IsCompatibleObject(item))
                return;

            Remove((T) item!);
        }
    }
}
#endif
