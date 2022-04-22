using System;
using System.Collections;
using System.Collections.Generic;

namespace Qommon.Collections.Proxied;

/// <summary>
///     Represents an implementation of <see cref="ICollection{T}"/> and <see cref="IReadOnlyCollection{T}"/>
///     by wrapping an <see cref="ICollection{T}"/> with virtual implementations making overriding individual members very simple.
/// </summary>
/// <typeparam name="T"> The type of values in the list. </typeparam>
public class ProxiedCollection<T> : ICollection<T>, ICollection, IReadOnlyCollection<T>
{
    /// <inheritdoc cref="ICollection{T}.Count"/>
    public virtual int Count => Collection.Count;

    /// <inheritdoc cref="ICollection{T}.IsReadOnly"/>
    public virtual bool IsReadOnly => Collection.IsReadOnly;

    /// <summary>
    ///     Gets the wrapped collection.
    /// </summary>
    protected ICollection<T> Collection { get; }

    /// <summary>
    ///     Instantiates a new <see cref="ProxiedCollection{T}"/>.
    /// </summary>
    /// <param name="collection"> The collection to wrap. </param>
    public ProxiedCollection(ICollection<T> collection)
    {
        Guard.IsNotNull(collection);

        Collection = collection;
    }

    /// <inheritdoc cref="ICollection{T}.Add"/>
    /// <returns>
    ///     <see langword="true"/> if the item was added.
    /// </returns>
    public virtual bool Add(T item)
    {
        Collection.Add(item);
        return true;
    }

    /// <inheritdoc cref="ICollection{T}.Clear"/>
    public virtual void Clear()
        => Collection.Clear();

    /// <inheritdoc/>
    public virtual bool Contains(T item)
        => Collection.Contains(item);

    /// <inheritdoc/>
    public virtual void CopyTo(T[] array, int arrayIndex)
        => Collection.CopyTo(array, arrayIndex);

    /// <inheritdoc/>
    public virtual bool Remove(T item)
        => Collection.Remove(item);

    /// <inheritdoc/>
    public virtual IEnumerator<T> GetEnumerator()
        => Collection.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();

    void ICollection<T>.Add(T item)
        => Add(item);

    object ICollection.SyncRoot => (Collection as ICollection)?.SyncRoot ?? this;

    bool ICollection.IsSynchronized => (Collection as ICollection)?.IsSynchronized ?? false;

    void ICollection.CopyTo(Array array, int index)
    {
        if (Collection is ICollection collection)
        {
            collection.CopyTo(array, index);
            return;
        }

        CopyTo((T[]) array, index);
    }
}