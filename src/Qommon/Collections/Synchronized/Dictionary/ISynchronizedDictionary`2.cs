using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Qommon.Collections.Synchronized
{
    /// <summary>
    ///     Represents a dictionary of which methods are synchronized by <see langword="lock"/>ing its instance.
    /// </summary>
    public interface ISynchronizedDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        new TKey[] Keys { get; }

        new TValue[] Values { get; }

        ICollection<TKey> IDictionary<TKey, TValue>.Keys => Keys;

        ICollection<TValue> IDictionary<TKey, TValue>.Values => Values;

        bool TryAdd(TKey key, TValue value);

        bool TryRemove(TKey key, [MaybeNullWhen(false)] out TValue value);

        KeyValuePair<TKey, TValue>[] ToArray();

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
            => (this.ToArray() as IList<KeyValuePair<TKey, TValue>>).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
