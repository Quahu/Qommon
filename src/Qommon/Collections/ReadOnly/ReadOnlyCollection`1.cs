﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Qommon.Collections
{
    public sealed class ReadOnlyCollection<T> : ICollection<T>, IReadOnlyCollection<T>
    {
        public static readonly IReadOnlyCollection<T> Empty = Array.Empty<T>().ReadOnly();

        public int Count => _collection.Count;

        private readonly ICollection<T> _collection;

        public ReadOnlyCollection(ICollection<T> collection)
        {
            Guard.IsNotNull(collection);

            _collection = collection;
        }

        public bool Contains(T item)
            => _collection.Contains(item);

        public void CopyTo(T[] array, int arrayIndex)
            => _collection.CopyTo(array, arrayIndex);

        public IEnumerator<T> GetEnumerator()
            => _collection.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        bool ICollection<T>.IsReadOnly => true;

        void ICollection<T>.Add(T item)
            => throw new NotSupportedException();

        void ICollection<T>.Clear()
            => throw new NotSupportedException();

        bool ICollection<T>.Remove(T item)
            => throw new NotSupportedException();
    }
}
