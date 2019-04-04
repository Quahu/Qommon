using System;
using System.Collections;
using System.Collections.Generic;

namespace Qommon.Collections
{
    public sealed class ReadOnlyDictionary<TKey, TValue> : IReadOnlyDictionary<TKey, TValue>
    {
        public IEnumerable<TKey> Keys => _dictionary.Keys;

        public IEnumerable<TValue> Values => _dictionary.Values;

        public int Count => _dictionary.Count;

        private readonly IReadOnlyDictionary<TKey, TValue> _dictionary;

        public ReadOnlyDictionary(IReadOnlyDictionary<TKey, TValue> dictionary)
        {
            if (dictionary is null)
                throw new ArgumentNullException(nameof(dictionary));

            _dictionary = dictionary;
        }

        public TValue this[TKey key] 
            => _dictionary[key];

        public bool ContainsKey(TKey key)
            => _dictionary.ContainsKey(key);

        public bool TryGetValue(TKey key, out TValue value)
            => _dictionary.TryGetValue(key, out value);

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
            => _dictionary.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
