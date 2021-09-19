using System.Collections.Generic;

namespace Qommon.Collections.Synchronized
{
    public static class SynchronizedCollectionExtensions
    {
        public static ISynchronizedDictionary<TKey, TValue> Synchronized<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
            => new SynchronizedDictionary<TKey, TValue>(dictionary);

        public static ISynchronizedList<T> Synchronized<T>(this IList<T> list)
            => new SynchronizedList<T>(list);
    }
}
