using System;
using System.Collections.Generic;
using Qommon.Collections.Proxied;

namespace Qommon.Collections.ReadOnly;

/// <summary>
///     Represents a read-only wrapper over a dictionary.
/// </summary>
/// <typeparam name="TKey"> The type of the keys. </typeparam>
/// <typeparam name="TValue"> The type of the values. </typeparam>
public class ReadOnlyDictionary<TKey, TValue> : ProxiedDictionary<TKey, TValue>
    where TKey : notnull
{
    public static readonly IReadOnlyDictionary<TKey, TValue> Empty = new Dictionary<TKey, TValue>(0).ReadOnly();

    /// <inheritdoc/>
    public override bool IsReadOnly => true;

    /// <inheritdoc/>
    public override ICollection<TKey> Keys => (Dictionary.Keys.ReadOnly() as ICollection<TKey>)!;

    /// <inheritdoc/>
    public override ICollection<TValue> Values => (Dictionary.Values.ReadOnly() as ICollection<TValue>)!;

    /// <inheritdoc/>
    public override TValue this[TKey key]
    {
        get => Dictionary[key];
        set => throw new NotSupportedException();
    }

    /// <summary>
    ///     Instantiates a new <see cref="ReadOnlyDictionary{TKey,TValue}"/> wrapping the provided dictionary.
    /// </summary>
    /// <param name="dictionary"> The dictionary to wrap. </param>
    public ReadOnlyDictionary(IDictionary<TKey, TValue> dictionary)
        : base(dictionary)
    { }

    /// <inheritdoc/>
    public override bool Add(KeyValuePair<TKey, TValue> item)
        => throw new NotSupportedException();

    /// <inheritdoc/>
    public override void Clear()
        => throw new NotSupportedException();

    /// <inheritdoc/>
    public override bool Remove(KeyValuePair<TKey, TValue> item)
        => throw new NotSupportedException();

    /// <inheritdoc/>
    public override void Add(TKey key, TValue value)
        => throw new NotSupportedException();

    /// <inheritdoc/>
    public override bool Remove(TKey key)
        => throw new NotSupportedException();
}
