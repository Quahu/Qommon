using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Qommon.Pooling;

public readonly partial struct RentedArray<T>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static RentedArray<T> Rent(int length, bool clearArray = false)
    {
        return Rent(length, ArrayPool<T>.Shared, clearArray);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static RentedArray<T> Rent(int length, ArrayPool<T> pool, bool clearArray = false)
    {
        Guard.IsNotNull(pool);

        return new(new(pool.Rent(length), 0, length), pool, clearArray);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static RentedArray<T> RentFor(ICollection<T> items)
    {
        var array = Rent(items.Count);
        items.CopyTo(array._segment.Array!, 0);
        return array;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static RentedArray<T> RentFor(T item)
    {
        var array = Rent(1);
        array[0] = item;
        return array;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static RentedArray<T> RentFor(T item1, T item2)
    {
        var array = Rent(2);
        array[0] = item1;
        array[1] = item2;
        return array;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static RentedArray<T> RentFor(T item1, T item2, T item3)
    {
        var array = Rent(3);
        array[0] = item1;
        array[1] = item2;
        array[2] = item3;
        return array;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static RentedArray<T> RentFor(T item1, T item2, T item3, T item4)
    {
        var array = Rent(4);
        array[0] = item1;
        array[1] = item2;
        array[2] = item3;
        array[3] = item4;
        return array;
    }
}
