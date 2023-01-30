using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Qommon.Buffers;

namespace Qommon.Pooling;

/// <summary>
///     Represents an array rented from an <see cref="ArrayPool{T}"/> that will be returned to it on disposal.
/// </summary>
/// <remarks>
///     Does not perform any validation checks on the underlying array nor on the pool.
/// </remarks>
/// <typeparam name="T"> The type of the elements in the array. </typeparam>
[DebuggerTypeProxy(typeof(RentedArrayDebuggerProxy<>))]
[DebuggerDisplay("{ToString(),raw}")]
public readonly partial struct RentedArray<T> : IList<T>, IReadOnlyList<T>, IDisposable
{
    private readonly ArraySegment<T> _segment;
    private readonly ArrayPool<T> _pool;
    private readonly bool _clearArray;

    public RentedArray(ArraySegment<T> segment, ArrayPool<T> pool, bool clearArray)
    {
        Guard.IsNotNull(pool);

        _segment = segment;
        _pool = pool;
        _clearArray = clearArray;
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"Qommon.Pooling.RentedArray<{typeof(T).Name}>[{Length}]";
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ref T GetPinnableReference()
    {
        return ref _segment.AsSpan().GetPinnableReference();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Dispose()
    {
        if (_segment.Array != null)
            _pool.Return(_segment.Array, _clearArray);
    }
}
