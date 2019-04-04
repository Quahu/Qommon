using System;
using System.Collections;
using System.Collections.Generic;

namespace Qommon.Collections
{
    public sealed class ReadOnlyCollection<T> : IReadOnlyCollection<T>
    {
        public int Count => _collection.Count;

        private readonly ICollection<T> _collection;

        public ReadOnlyCollection(ICollection<T> collection)
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));

            _collection = collection;
        }

        public IEnumerator<T> GetEnumerator()
            => _collection.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
