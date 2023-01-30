using System.Diagnostics;

namespace Qommon.Buffers;

internal sealed class NativeArrayDebuggerProxy<T>
    where T : unmanaged
{
    [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
    public T[] Items => _items;

    private readonly T[] _items;

    public NativeArrayDebuggerProxy(NativeArray<T> nativeArray)
    {
        _items = nativeArray.ToArray();
    }
}
