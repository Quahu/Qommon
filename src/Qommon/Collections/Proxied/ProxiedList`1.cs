using System.Collections;
using System.Collections.Generic;

namespace Qommon.Collections.Proxied;

/// <summary>
///     Represents an implementation of <see cref="IList{T}"/> and <see cref="IReadOnlyList{T}"/>
///     by wrapping an <see cref="IList{T}"/> with virtual implementations making overriding individual members very simple.
/// </summary>
/// <typeparam name="T"> The type of values in the list. </typeparam>
public class ProxiedList<T> : ProxiedCollection<T>,
    IList<T>, IList, IReadOnlyList<T>
{
    /// <inheritdoc cref="IList{T}.this"/>
    public virtual T this[int index]
    {
        get => List[index];
        set => List[index] = value;
    }

    /// <summary>
    ///     Gets the wrapped list.
    /// </summary>
    protected virtual IList<T> List => (Collection as IList<T>)!;

    /// <summary>
    ///     Instantiates a new <see cref="ProxiedList{T}"/> wrapping a <see cref="List{T}"/>.
    /// </summary>
    /// <param name="capacity"> The initial capacity of the list. </param>
    protected ProxiedList(int capacity = 0)
        : base(new List<T>(capacity))
    { }

    /// <summary>
    ///     Instantiates a new <see cref="ProxiedList{T}"/>.
    /// </summary>
    /// <param name="list"> The list to wrap. </param>
    public ProxiedList(IList<T> list)
        : base(list)
    { }

    /// <inheritdoc/>
    public virtual int IndexOf(T item)
        => List.IndexOf(item);

    /// <inheritdoc/>
    public virtual void Insert(int index, T item)
        => List.Insert(index, item);

    /// <inheritdoc cref="IList{T}.RemoveAt"/>
    public virtual void RemoveAt(int index)
        => List.RemoveAt(index);

    bool IList.IsFixedSize => (List as IList)?.IsFixedSize ?? false;

    object? IList.this[int index]
    {
        get => this[index];
        set => this[index] = (T) value!;
    }

    int IList.Add(object? value)
    {
        Add((T) value!);
        return Count - 1; // Violates the IList contract, but in practice doesn't matter
    }

    bool IList.Contains(object? value)
    {
        return Contains((T) value!);
    }

    int IList.IndexOf(object? value)
    {
        return IndexOf((T) value!);
    }

    void IList.Insert(int index, object? value)
    {
        Insert(index, (T) value!);
    }

    void IList.Remove(object? value)
    {
        Remove((T) value!);
    }
}