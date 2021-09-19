﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Qommon.Collections
{
    public sealed class ReadOnlyList<T> : IList<T>, IReadOnlyList<T>
    {
        public static readonly IReadOnlyList<T> Empty = Array.Empty<T>().ReadOnly();

        public int Count => _list.Count;

        public T this[int index]
        {
            get => _list[index];
            set => throw new NotSupportedException();
        }

        private readonly IList<T> _list;

        public ReadOnlyList(IList<T> list)
        {
            Guard.IsNotNull(list);

            _list = list;
        }

        public int IndexOf(T item)
            => _list.IndexOf(item);

        public bool Contains(T item)
            => _list.Contains(item);

        public void CopyTo(T[] array, int arrayIndex)
            => _list.CopyTo(array, arrayIndex);

        public IEnumerator<T> GetEnumerator()
            => _list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        bool ICollection<T>.IsReadOnly => true;

        void IList<T>.Insert(int index, T item)
            => throw new NotSupportedException();

        void IList<T>.RemoveAt(int index)
            => throw new NotSupportedException();

        void ICollection<T>.Add(T item)
            => throw new NotSupportedException();

        void ICollection<T>.Clear()
            => throw new NotSupportedException();

        bool ICollection<T>.Remove(T item)
            => throw new NotSupportedException();
    }
}
