using System.Collections.Generic;
using System.ComponentModel;

namespace Qommon.Collections.Synchronized;

[EditorBrowsable(EditorBrowsableState.Never)]
public static class SynchronizedCollectionExtensions
{
    public static ISynchronizedDictionary<TKey, TValue> Synchronized<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        where TKey : notnull
        => new SynchronizedDictionary<TKey, TValue>(dictionary);

    public static ISynchronizedList<T> Synchronized<T>(this IList<T> list)
        => new SynchronizedList<T>(list);
}