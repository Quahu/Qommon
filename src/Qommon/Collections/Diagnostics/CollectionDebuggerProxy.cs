using System.Collections.Generic;
using System.Diagnostics;

namespace Qommon.Collections;

internal sealed class CollectionDebuggerProxy<T>
{
    [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
    public T[] Items
    {
        get
        {
            var items = new T[_collection.Count];
            _collection.CopyTo(items, 0);
            return items;
        }
    }

    private readonly ICollection<T> _collection;

    public CollectionDebuggerProxy(ICollection<T> collection)
    {
        Guard.IsNotNull(collection);

        _collection = collection;
    }
}
