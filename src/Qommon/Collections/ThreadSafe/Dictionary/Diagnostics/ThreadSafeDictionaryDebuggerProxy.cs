using System.Collections.Generic;
using System.Diagnostics;

namespace Qommon.Collections.ThreadSafe;

internal sealed class ThreadSafeDictionaryDebuggerProxy<TKey, TValue>
    where TKey : notnull
{
    [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
    public KeyValuePair<TKey, TValue>[] Items => _dictionary.ToArray();

    private readonly IThreadSafeDictionary<TKey, TValue> _dictionary;

    public ThreadSafeDictionaryDebuggerProxy(IThreadSafeDictionary<TKey, TValue> dictionary)
    {
        Guard.IsNotNull(dictionary);

        _dictionary = dictionary;
    }
}
