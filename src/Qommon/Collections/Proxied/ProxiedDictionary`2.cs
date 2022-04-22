using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Qommon.Collections.Proxied;

/// <summary>
///     Represents an implementation of <see cref="IDictionary{TKey,TValue}"/> and <see cref="IReadOnlyDictionary{TKey,TValue}"/>
///     by wrapping an <see cref="IDictionary{TKey, TValue}"/> with virtual implementations making overriding individual members very simple.
/// </summary>
/// <typeparam name="TKey"> The type of keys in the dictionary. </typeparam>
/// <typeparam name="TValue"> The type of values in the dictionary. </typeparam>
public class ProxiedDictionary<TKey, TValue> : ProxiedCollection<KeyValuePair<TKey, TValue>>,
    IDictionary<TKey, TValue>, IDictionary, IReadOnlyDictionary<TKey, TValue>
    where TKey : notnull
{
    /// <inheritdoc/>
    public virtual ICollection<TKey> Keys => Dictionary.Keys;

    /// <inheritdoc/>
    public virtual ICollection<TValue> Values => Dictionary.Values;

    /// <inheritdoc cref="IDictionary{TKey,TValue}.this"/>
    public virtual TValue this[TKey key]
    {
        get => Dictionary[key];
        set => Dictionary[key] = value;
    }

    IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys => Keys;

    IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values => Values;

    /// <summary>
    ///     Gets the wrapped dictionary.
    /// </summary>
    protected virtual IDictionary<TKey, TValue> Dictionary => (Collection as IDictionary<TKey, TValue>)!;

    /// <summary>
    ///     Instantiates a new <see cref="ProxiedDictionary{TKey, TValue}"/> wrapping a <see cref="Dictionary{TKey,TValue}"/>.
    /// </summary>
    /// <param name="capacity"> The initial capacity of the dictionary. </param>
    /// <param name="comparer"> The equality comparer for the dictionary keys. </param>
    protected ProxiedDictionary(int capacity = 0, IEqualityComparer<TKey>? comparer = null)
        : base(new Dictionary<TKey, TValue>(capacity, comparer))
    { }

    /// <summary>
    ///     Instantiates a new <see cref="ProxiedDictionary{TKey, TValue}"/>.
    /// </summary>
    /// <param name="dictionary"> The dictionary to wrap. </param>
    public ProxiedDictionary(IDictionary<TKey, TValue> dictionary)
        : base(dictionary)
    { }

    /// <inheritdoc/>
    public virtual void Add(TKey key, TValue value)
        => Dictionary.Add(key, value);

    /// <inheritdoc cref="IDictionary{TKey,TValue}.ContainsKey"/>
    public virtual bool ContainsKey(TKey key)
        => Dictionary.ContainsKey(key);

    /// <inheritdoc/>
    public virtual bool Remove(TKey key)
        => Dictionary.Remove(key);

    /// <inheritdoc cref="IDictionary{TKey,TValue}.TryGetValue"/>
    public virtual bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        => Dictionary.TryGetValue(key, out value);

    bool IDictionary.IsFixedSize => (Dictionary as IDictionary)?.IsFixedSize ?? false;

    ICollection IDictionary.Keys => (Keys as ICollection)!;

    ICollection IDictionary.Values => (Values as ICollection)!;

    object? IDictionary.this[object key]
    {
        get => this[(TKey) key];
        set => this[(TKey) key] = (TValue) value!;
    }

    void IDictionary.Add(object key, object? value)
    {
        Add((TKey) key, (TValue) value!);
    }

    bool IDictionary.Contains(object key)
    {
        return ContainsKey((TKey) key);
    }

    void IDictionary.Remove(object key)
    {
        Remove((TKey) key);
    }

    IDictionaryEnumerator IDictionary.GetEnumerator()
        => new Enumerator(GetEnumerator());

    private sealed class Enumerator : IDictionaryEnumerator
    {
        public object Current => _enumerator.Current;

        public DictionaryEntry Entry => new(_enumerator.Current.Key, _enumerator.Current.Value);

        public object Key => _enumerator.Current.Key;

        public object? Value => _enumerator.Current.Value;

        private readonly IEnumerator<KeyValuePair<TKey, TValue>> _enumerator;

        public Enumerator(IEnumerator<KeyValuePair<TKey, TValue>> enumerator)
        {
            _enumerator = enumerator;
        }

        public bool MoveNext()
        {
            return _enumerator.MoveNext();
        }

        public void Reset()
        {
            _enumerator.Reset();
        }
    }
}