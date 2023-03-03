using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Qommon.Collections.ThreadSafe;

/// <inheritdoc cref="IThreadSafeDictionary{TKey,TValue}"/>
[DebuggerTypeProxy(typeof(ThreadSafeDictionaryDebuggerProxy<,>))]
[DebuggerDisplay("Count = {Count}")]
public abstract class ThreadSafeDictionary<TKey, TValue> : IThreadSafeDictionary<TKey, TValue>, IDictionary, IReadOnlyDictionary<TKey, TValue>
    where TKey : notnull
{
    /// <inheritdoc/>
    public abstract TKey[] Keys { get; }

    /// <inheritdoc/>
    public abstract TValue[] Values { get; }

    /// <summary>
    ///     Gets the amount of key/value pairs of this dictionary.
    /// </summary>
    public abstract int Count { get; }

    /// <inheritdoc/>
    public abstract bool IsEmpty { get; }

    /// <inheritdoc/>
    public abstract bool IsReadOnly { get; }

    /// <summary>
    ///     Gets or sets the value for the specified key in this dictionary.
    /// </summary>
    /// <exception cref="ArgumentNullException"> Thrown when <paramref name="key"/> is null. </exception>
    /// <exception cref="KeyNotFoundException"> Thrown when attempting to get the value of <paramref name="key"/> that does not exist in the dictionary. </exception>
    public abstract TValue this[TKey key] { get; set; }

    ICollection<TKey> IDictionary<TKey, TValue>.Keys => Keys;

    ICollection<TValue> IDictionary<TKey, TValue>.Values => Values;

    bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;

    IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys => Keys;

    IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values => Values;

    object? IDictionary.this[object key]
    {
        get
        {
            if (IsCompatibleKey(key) && TryGetValue((TKey) key, out var value))
            {
                return value;
            }

            return null;
        }
        set => this[(TKey) key] = (TValue) value!;
    }

    ICollection IDictionary.Keys => Keys;

    ICollection IDictionary.Values => Values;

    bool IDictionary.IsFixedSize => false;

    object ICollection.SyncRoot => throw new NotSupportedException();

    bool ICollection.IsSynchronized => false;

    /// <summary>
    ///     Instantiates a new <see cref="ThreadSafeDictionary{TKey,TValue}"/>.
    /// </summary>
    protected ThreadSafeDictionary()
    { }

    private static bool IsCompatibleKey(object key)
    {
        Guard.IsNotNull(key);
        return key is TKey;
    }

    /// <inheritdoc/>
    public abstract bool TryAdd(TKey key, TValue value);

    /// <inheritdoc/>
    public abstract TValue GetOrAdd(TKey key, TValue value);

    /// <inheritdoc/>
    public abstract TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory);

    /// <inheritdoc/>
    public abstract TValue GetOrAdd<TState>(TKey key, Func<TKey, TState, TValue> valueFactory, TState state);

    /// <inheritdoc/>
    public abstract TValue AddOrUpdate(TKey key, TValue addValue, Func<TKey, TValue, TValue> updateFactory);

    /// <inheritdoc/>
    public abstract TValue AddOrUpdate(TKey key, Func<TKey, TValue> addFactory, Func<TKey, TValue, TValue> updateFactory);

    /// <inheritdoc/>
    public abstract TValue AddOrUpdate<TState>(TKey key, Func<TKey, TState, TValue> addFactory, Func<TKey, TValue, TState, TValue> updateFactory, TState state);

    /// <inheritdoc/>
    public abstract bool TryUpdate(TKey key, TValue newValue, TValue comparisonValue);

    /// <inheritdoc/>
    public abstract bool TryRemove(TKey key, [MaybeNullWhen(false)] out TValue value);

    /// <inheritdoc/>
    public abstract KeyValuePair<TKey, TValue>[] ToArray();

    /// <summary>
    ///     Checks whether the specified key exists in this dictionary.
    /// </summary>
    /// <param name="key"> The key to check. </param>
    /// <returns>
    ///     <see langword="true"/> if this dictionary contains the specified key.
    /// </returns>
    /// <exception cref="ArgumentNullException"> Thrown when <paramref name="key"/> is null. </exception>
    public abstract bool ContainsKey(TKey key);

    /// <summary>
    ///     Adds the specified key with the specified value.
    /// </summary>
    /// <param name="key"> The key to add the value for. </param>
    /// <param name="value"> The value to add for the key. </param>
    /// <exception cref="ArgumentNullException"> Thrown when <paramref name="key"/> is null. </exception>
    /// <exception cref="ArgumentException"> Thrown when <paramref name="key"/> already exists in the dictionary. </exception>
    public abstract void Add(TKey key, TValue value);

    /// <summary>
    ///     Removes the specified key from this dictionary.
    /// </summary>
    /// <param name="key"> The key to remove. </param>
    /// <returns>
    ///     <see langword="true"/> if the key was found and removed.
    /// </returns>
    /// <exception cref="ArgumentNullException"> Thrown when <paramref name="key"/> is null. </exception>
    public abstract bool Remove(TKey key);

    /// <summary>
    ///     Clears the contents of this dictionary.
    /// </summary>
    public abstract void Clear();

    /// <summary>
    ///     Attempts to get the value of the specified key.
    /// </summary>
    /// <param name="key"> The key whose value to get. </param>
    /// <param name="value"> The output value. </param>
    /// <returns>
    ///     <see langword="true"/> if this dictionary contains the specified key.
    /// </returns>
    /// <exception cref="ArgumentNullException"> Thrown when <paramref name="key"/> is null. </exception>
    public abstract bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value);

    /// <summary>
    ///     Copies the contents of this dictionary to the specified key/value pair array.
    /// </summary>
    /// <param name="array"> The array to copy the contents to. </param>
    /// <param name="arrayIndex"> The array index at which the copying begins. </param>
    /// <exception cref="ArgumentNullException"> Thrown when <paramref name="array"/> is null. </exception>
    /// <exception cref="ArgumentOutOfRangeException"> Thrown when <paramref name="arrayIndex"/> is invalid. </exception>
    public abstract void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex);

    /// <summary>
    ///     Gets an enumerator that allows for enumeration of this dictionary.
    /// </summary>
    /// <returns>
    ///     The enumerator.
    /// </returns>
    public abstract IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
    {
        return ContainsKey(item.Key);
    }

    void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
    {
        Add(item.Key, item.Value);
    }

    bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
    {
        return Remove(item.Key);
    }

    bool IDictionary.Contains(object key)
    {
        if (IsCompatibleKey(key))
        {
            return ContainsKey((TKey) key);
        }

        return false;
    }

    void IDictionary.Add(object key, object? value)
    {
        Add((TKey) key, (TValue) value!);
    }

    void IDictionary.Remove(object key)
    {
        if (IsCompatibleKey(key))
        {
            Remove((TKey) key);
        }
    }

    void ICollection.CopyTo(Array array, int index)
    {
        Guard.IsNotNull(array);
        Guard.IsNotMultiDimensional(array);
        Guard.IsEqualTo(array.GetLowerBound(0), 0);
        Guard.IsGreaterThan(array.Length, index);

        if (array is KeyValuePair<TKey, TValue>[] pairs)
        {
            CopyTo(pairs, index);
        }
        else
        {
            var items = ToArray();
            Guard.IsGreaterThanOrEqualTo(array.Length - items.Length, index);

            if (array is DictionaryEntry[] entries)
            {
                foreach (var item in items)
                {
                    entries[index++] = new DictionaryEntry(item.Key, item.Value);
                }
            }
            else
            {
                var objects = Guard.IsOfType<object[]>(array);
                foreach (var item in items)
                {
                    objects[index++] = new KeyValuePair<TKey, TValue>(item.Key, item.Value);
                }
            }
        }
    }

    IDictionaryEnumerator IDictionary.GetEnumerator()
    {
        return new Enumerator(GetEnumerator());
    }

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
