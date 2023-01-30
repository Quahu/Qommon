using System;
using System.Collections.Generic;
using Qommon.Collections.Proxied;

namespace Qommon.Collections.ReadOnly;

/// <summary>
///     Represents a read-only wrapper over a set.
/// </summary>
/// <typeparam name="T"> The type of the items. </typeparam>
public class ReadOnlySet<T> : ProxiedSet<T>
{
    /// <summary>
    ///     Gets a singleton empty instance of this type.
    /// </summary>
    public static IReadOnlySet<T> Empty => EmptyReadOnlyInstances.Set<T>.Instance;

    /// <inheritdoc/>
    public override bool IsReadOnly => true;

    /// <summary>
    ///     Instantiates a new <see cref="ReadOnlySet{T}"/> wrapping the provided set.
    /// </summary>
    /// <param name="set"> The set to wrap. </param>
    public ReadOnlySet(ISet<T> set)
        : base(set)
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
    public override void ExceptWith(IEnumerable<T> other)
        => throw new NotSupportedException();

    /// <inheritdoc/>
    public override void IntersectWith(IEnumerable<T> other)
        => throw new NotSupportedException();

    /// <inheritdoc/>
    public override void SymmetricExceptWith(IEnumerable<T> other)
        => throw new NotSupportedException();

    /// <inheritdoc/>
    public override void UnionWith(IEnumerable<T> other)
        => throw new NotSupportedException();
}
