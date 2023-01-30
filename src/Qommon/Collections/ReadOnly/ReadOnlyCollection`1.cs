using System;
using System.Collections.Generic;
using Qommon.Collections.Proxied;

namespace Qommon.Collections.ReadOnly;

/// <summary>
///     Represents a read-only wrapper over a collection.
/// </summary>
/// <typeparam name="T"> The type of the items. </typeparam>
public class ReadOnlyCollection<T> : ProxiedCollection<T>
{
    /// <summary>
    ///     Gets a singleton empty instance of this type.
    /// </summary>
    public static IReadOnlyCollection<T> Empty => EmptyReadOnlyInstances.List<T>.Instance;

    /// <inheritdoc/>
    public override bool IsReadOnly => true;

    /// <summary>
    ///     Instantiates a new <see cref="ReadOnlyCollection{T}"/> wrapping the provided collection.
    /// </summary>
    /// <param name="collection"> The collection to wrap. </param>
    public ReadOnlyCollection(ICollection<T> collection)
        : base(collection)
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
}
