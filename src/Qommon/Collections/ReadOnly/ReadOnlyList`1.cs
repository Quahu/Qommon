using System;
using System.Collections.Generic;
using Qommon.Collections.Proxied;

namespace Qommon.Collections.ReadOnly;

/// <summary>
///     Represents a read-only wrapper over a list.
/// </summary>
/// <typeparam name="T"> The type of the items. </typeparam>
public class ReadOnlyList<T> : ProxiedList<T>
{
    public static readonly IReadOnlyList<T> Empty = Array.Empty<T>().ReadOnly();

    /// <inheritdoc/>
    public override bool IsReadOnly => true;

    /// <inheritdoc/>
    public override T this[int index]
    {
        get => base[index];
        set => throw new NotSupportedException();
    }

    /// <summary>
    ///     Instantiates a new <see cref="ReadOnlyList{T}"/> wrapping the provided list.
    /// </summary>
    /// <param name="list"> The list to wrap. </param>
    public ReadOnlyList(IList<T> list)
        : base(list)
    { }

    /// <inheritdoc/>
    public override bool Add(T item)
        => throw new NotSupportedException();

    /// <inheritdoc/>
    public override void Clear()
        => throw new NotSupportedException();

    /// <inheritdoc/>
    public override bool Remove(T item)
        => throw new NotSupportedException();

    /// <inheritdoc/>
    public override void Insert(int index, T item)
        => throw new NotSupportedException();

    /// <inheritdoc/>
    public override void RemoveAt(int index)
        => throw new NotSupportedException();
}
