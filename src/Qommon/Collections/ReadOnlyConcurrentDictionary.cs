using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Qommon.Collections
{
    /// <summary>
    ///     Represents a read-only wrapper for the <see cref="ConcurrentDictionary{TKey, TValue}"/> collection.
    /// </summary>
    /// <typeparam name="TKey"> The <see cref="Type"/> of the keys in the dictionary. </typeparam>
    /// <typeparam name="TValue"> The <see cref="Type"/> of the values in the dictionary. </typeparam>
    public sealed class ReadOnlyConcurrentDictionary<TKey, TValue> : IReadOnlyDictionary<TKey, TValue>
    {
        /// <summary>
        ///     Gets the keys collection of the underlying <see cref="ConcurrentDictionary{TKey, TValue}"/>.
        /// </summary>
        public IReadOnlyCollection<TKey> Keys => new ReadOnlyCollection<TKey>(_dictionary.Keys);

        /// <summary>
        ///     Gets the keys collection of the underlying <see cref="ConcurrentDictionary{TKey, TValue}"/>.
        /// </summary>
        public IReadOnlyCollection<TValue> Values => new ReadOnlyCollection<TValue>(_dictionary.Values);

        /// <summary>
        ///     Gets the number of key/value pairs in the underlying <see cref="ConcurrentDictionary{TKey, TValue}"/>.
        /// </summary>
        public int Count => _dictionary.Count;

        IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys => Keys;
        IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values => Values;

        private readonly ConcurrentDictionary<TKey, TValue> _dictionary;

        /// <summary>
        ///     Initialises a new instance of <see cref="ReadOnlyConcurrentDictionary{TKey, TValue}"/> 
        ///     wrapping the specified <<see cref="ConcurrentDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <param name="dictionary"> The <see cref="ConcurrentDictionary{TKey, TValue}"/> to wrap. </param>
        public ReadOnlyConcurrentDictionary(ConcurrentDictionary<TKey, TValue> dictionary)
        {
            if (dictionary is null)
                throw new ArgumentNullException(nameof(dictionary));

            _dictionary = dictionary;
        }

        /// <summary>
        ///     Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key"> The key of the value to get. </param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="key"/> is <see langword="null"/>.
        /// <exception>
        /// <exception cref="KeyNotFoundException">
        ///     <paramref name="key"/> does not exist in the collection.
        /// </exception>
        public TValue this[TKey key]
            => _dictionary[key];

        /// <summary>
        ///     Determines whether the underlying <see cref="ConcurrentDictionary{TKey, TValue}"/> contains the specified key.
        /// </summary>
        /// <param name="key"> The key to check for. </param>
        public bool ContainsKey(TKey key)
            => _dictionary.ContainsKey(key);

        /// <summary>
        ///     Attempts to get the value associated with the specified key from the underlying <see cref="ConcurrentDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <param name="key"> The key of the value to get. </param>
        /// <param name="value"> The <see langword="out"/> value associated with the specified key. </param>
        public bool TryGetValue(TKey key, out TValue value)
            => _dictionary.TryGetValue(key, out value);

        /// <summary>
        ///     Copies the key/value pairs from the underlying <see cref="ConcurrentDictionary{TKey, TValue}"/> to a new array.
        /// </summary>
        public KeyValuePair<TKey, TValue>[] ToArray()
            => _dictionary.ToArray();

        /// <summary>
        ///     Returns an enumerator that iterates through the underlying <see cref="ConcurrentDictionary{TKey, TValue}"/>.
        /// </summary>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
            => _dictionary.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
