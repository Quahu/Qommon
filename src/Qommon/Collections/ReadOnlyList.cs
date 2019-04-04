using System;
using System.Collections;
using System.Collections.Generic;

namespace Qommon.Collections
{
    public sealed class ReadOnlyList<T> : IReadOnlyList<T>
    {
        public int Count => _list.Count;

        private readonly IReadOnlyList<T> _list;

        public ReadOnlyList(IReadOnlyList<T> list)
        {
            if (list is null)
                throw new ArgumentNullException(nameof(list));

            _list = list;
        }

        public T this[int index]
            => _list[index];

        public IEnumerator<T> GetEnumerator()
            => _list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
