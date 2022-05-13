using System.Collections.Generic;
using System.ComponentModel;

namespace Qommon.Collections.Synchronized;

[EditorBrowsable(EditorBrowsableState.Never)]
public static class SynchronizedCollectionExtensions
{
    public static ISynchronizedDictionary<TKey, TValue> Synchronized<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        where TKey : notnull
    {
        if (dictionary is ISynchronizedDictionary<TKey, TValue> synchronizedDictionary)
            return synchronizedDictionary;

        return new SynchronizedDictionary<TKey, TValue>(dictionary);
    }

    public static ISynchronizedList<T> Synchronized<T>(this IList<T> list)
    {
        if (list is ISynchronizedList<T> synchronizedList)
            return synchronizedList;

        return new SynchronizedList<T>(list);
    }
}
