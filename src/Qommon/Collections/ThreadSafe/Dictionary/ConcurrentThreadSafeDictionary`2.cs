using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Qommon.Collections.ThreadSafe;

/// <remarks>
///     This type uses <see cref="ConcurrentDictionary{TKey,TValue}"/> for synchronization.
/// </remarks>
internal sealed class ConcurrentThreadSafeDictionary<TKey, TValue> : ThreadSafeDictionary<TKey, TValue>
    where TKey : notnull
{
    public override TKey[] Keys => _dictionary.Keys.GetArray();

    public override TValue[] Values => _dictionary.Values.GetArray();

    public override int Count => _dictionary.Count;

    public override bool IsEmpty => _dictionary.IsEmpty;

    public override bool IsReadOnly => false;

    public override TValue this[TKey key]
    {
        get => _dictionary[key];
        set => _dictionary[key] = value;
    }

    private readonly ConcurrentDictionary<TKey, TValue> _dictionary;

    public ConcurrentThreadSafeDictionary(ConcurrentDictionary<TKey, TValue> dictionary)
    {
        _dictionary = dictionary;
    }

    public override bool TryAdd(TKey key, TValue value)
    {
        return _dictionary.TryAdd(key, value);
    }

    public override TValue GetOrAdd(TKey key, TValue value)
    {
        return _dictionary.GetOrAdd(key, value);
    }

    public override TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory)
    {
        return _dictionary.GetOrAdd(key, valueFactory);
    }

    public override TValue GetOrAdd<TState>(TKey key, Func<TKey, TState, TValue> valueFactory, TState state)
    {
        return _dictionary.GetOrAdd(key, valueFactory, state);
    }

    public override TValue AddOrUpdate(TKey key, TValue addValue, Func<TKey, TValue, TValue> updateFactory)
    {
        return _dictionary.AddOrUpdate(key, addValue, updateFactory);
    }

    public override TValue AddOrUpdate(TKey key, Func<TKey, TValue> addFactory, Func<TKey, TValue, TValue> updateFactory)
    {
        return _dictionary.AddOrUpdate(key, addFactory, updateFactory);
    }

    public override TValue AddOrUpdate<TState>(TKey key, Func<TKey, TState, TValue> addFactory, Func<TKey, TValue, TState, TValue> updateFactory, TState state)
    {
        return _dictionary.AddOrUpdate(key, addFactory, updateFactory, state);
    }

    public override bool TryUpdate(TKey key, TValue newValue, TValue comparisonValue)
    {
        return _dictionary.TryUpdate(key, newValue, comparisonValue);
    }

    public override bool TryRemove(TKey key, [MaybeNullWhen(false)] out TValue value)
    {
        return _dictionary.TryRemove(key, out value);
    }

    public override KeyValuePair<TKey, TValue>[] ToArray()
    {
        return _dictionary.ToArray();
    }

    public override bool ContainsKey(TKey key)
    {
        return _dictionary.ContainsKey(key);
    }

    public override void Add(TKey key, TValue value)
    {
        if (!_dictionary.TryAdd(key, value))
        {
            Throw.ArgumentException("The key already exists in the dictionary.", nameof(key));
        }
    }

    public override bool Remove(TKey key)
    {
        return _dictionary.TryRemove(key, out _);
    }

    public override void Clear()
    {
        _dictionary.Clear();
    }

    public override bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
    {
        return _dictionary.TryGetValue(key, out value);
    }

    public override void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
    {
        (_dictionary as ICollection<KeyValuePair<TKey, TValue>>).CopyTo(array, arrayIndex);
    }

    public override IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        return (ToArray() as IList<KeyValuePair<TKey, TValue>>).GetEnumerator();
    }
}
