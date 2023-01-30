using System.Collections.Generic;
using System.Diagnostics;

namespace Qommon.Collections;

internal sealed class DictionaryDebuggerProxy<TKey, TValue>
    where TKey : notnull
{
    [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
    public KeyValuePair<TKey, TValue>[] Items
    {
        get
        {
            var items = new KeyValuePair<TKey, TValue>[_dict.Count];
            _dict.CopyTo(items, 0);
            return items;
        }
    }

    private readonly IDictionary<TKey, TValue> _dict;

    public DictionaryDebuggerProxy(IDictionary<TKey, TValue> dictionary)
    {
        Guard.IsNotNull(dictionary);

        _dict = dictionary;
    }
}
