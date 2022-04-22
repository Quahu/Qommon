using System.Collections.Generic;

namespace Qommon.Collections.Proxied;

/// <summary>
///     Represents an implementation of <see cref="IList{T}"/> and <see cref="IReadOnlyList{T}"/>
///     by wrapping an <see cref="IList{T}"/> with virtual implementations making overriding individual members very simple.
/// </summary>
/// <typeparam name="T"> The type of values in the list. </typeparam>
public class ProxiedSet<T> : ProxiedCollection<T>,
    ISet<T>, IReadOnlySet<T>
{
    /// <summary>
    ///     Gets the wrapped set.
    /// </summary>
    protected virtual ISet<T> Set => (Collection as ISet<T>)!;

    /// <summary>
    ///     Instantiates a new <see cref="ProxiedSet{T}"/> wrapping a <see cref="HashSet{T}"/>.
    /// </summary>
    /// <param name="capacity"> The initial capacity of the list. </param>
    protected ProxiedSet(int capacity = 0)
        : base(new HashSet<T>(capacity))
    { }

    /// <summary>
    ///     Instantiates a new <see cref="ProxiedSet{T}"/>.
    /// </summary>
    /// <param name="set"> The set to wrap. </param>
    public ProxiedSet(ISet<T> set)
        : base(set)
    { }

    public override bool Add(T item)
        => Set.Add(item);

    /// <inheritdoc/>
    public virtual void UnionWith(IEnumerable<T> other)
        => Set.UnionWith(other);

    /// <inheritdoc/>
    public virtual void IntersectWith(IEnumerable<T> other)
        => Set.IntersectWith(other);

    /// <inheritdoc/>
    public virtual void ExceptWith(IEnumerable<T> other)
        => Set.ExceptWith(other);

    /// <inheritdoc/>
    public virtual void SymmetricExceptWith(IEnumerable<T> other)
        => Set.SymmetricExceptWith(other);

    /// <inheritdoc cref="IReadOnlySet{T}.IsSubsetOf"/>
    public virtual bool IsSubsetOf(IEnumerable<T> other)
        => Set.IsSubsetOf(other);

    /// <inheritdoc cref="IReadOnlySet{T}.IsSupersetOf"/>
    public virtual bool IsSupersetOf(IEnumerable<T> other)
        => Set.IsSupersetOf(other);

    /// <inheritdoc cref="IReadOnlySet{T}.IsProperSupersetOf"/>
    public virtual bool IsProperSupersetOf(IEnumerable<T> other)
        => Set.IsProperSupersetOf(other);

    /// <inheritdoc cref="IReadOnlySet{T}.IsProperSubsetOf"/>
    public virtual bool IsProperSubsetOf(IEnumerable<T> other)
        => Set.IsProperSubsetOf(other);

    /// <inheritdoc cref="IReadOnlySet{T}.Overlaps"/>
    public virtual bool Overlaps(IEnumerable<T> other)
        => Set.Overlaps(other);

    /// <inheritdoc cref="IReadOnlySet{T}.SetEquals"/>
    public virtual bool SetEquals(IEnumerable<T> other)
        => Set.SetEquals(other);
}
