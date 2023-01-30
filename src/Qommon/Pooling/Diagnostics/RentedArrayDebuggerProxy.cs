using System.Diagnostics;

namespace Qommon.Pooling;

internal sealed class RentedArrayDebuggerProxy<T>
    where T : unmanaged
{
    [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
    public T[] Items
    {
        get
        {
            var items = new T[_rentedArray.Length];
            _rentedArray.CopyTo(items, 0);
            return items;
        }
    }

    private readonly RentedArray<T> _rentedArray;

    public RentedArrayDebuggerProxy(RentedArray<T> rentedArray)
    {
        _rentedArray = rentedArray;
    }
}
