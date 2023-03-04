using System.Diagnostics;

namespace Qommon.Buffers;

internal sealed class NativeListDebuggerProxy<T>
    where T : unmanaged
{
    [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
    public T[] Items => _items;

    private readonly T[] _items;

    public NativeListDebuggerProxy(NativeArray<T> nativeArray)
    {
        _items = nativeArray.ToArray();
    }
}
