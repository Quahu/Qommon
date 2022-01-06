using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Qommon.Collections.Synchronized
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class SynchronizedDictionaryExtensions
    {
        public static KeyValuePair<TKey, TValue>[] ToArray<TKey, TValue>(this ISynchronizedDictionary<TKey, TValue> dictionary)
        {
            lock (dictionary)
            {
                var array = new KeyValuePair<TKey, TValue>[dictionary.Count];
                dictionary.CopyTo(array, 0);
                return array;
            }
        }

        public static TValue GetValueOrDefault<TKey, TValue>(this ISynchronizedDictionary<TKey, TValue> dictionary, TKey key)
            => dictionary.TryGetValue(key, out var value)
                ? value
                : default;

        public static TValue GetOrAdd<TKey, TValue>(this ISynchronizedDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            lock (dictionary)
            {
                if (dictionary.TryGetValue(key, out var existingValue))
                    return existingValue;

                dictionary.Add(key, value);
                return value;
            }
        }

        public static TValue GetOrAdd<TKey, TValue>(this ISynchronizedDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> factory)
        {
            lock (dictionary)
            {
                if (dictionary.TryGetValue(key, out var value))
                    return value;

                value = factory(key);
                dictionary.Add(key, value);
                return value;
            }
        }

        public static TValue GetOrAdd<TKey, TValue, TState>(this ISynchronizedDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TState, TValue> factory, TState state)
        {
            lock (dictionary)
            {
                if (dictionary.TryGetValue(key, out var value))
                    return value;

                value = factory(key, state);
                dictionary.Add(key, value);
                return value;
            }
        }

        public static TValue AddOrUpdate<TKey, TValue>(this ISynchronizedDictionary<TKey, TValue> dictionary, TKey key, TValue addValue, Func<TKey, TValue, TValue> updateFactory)
        {
            lock (dictionary)
            {
                if (dictionary.TryGetValue(key, out var value))
                {
                    value = updateFactory(key, value);
                    dictionary[key] = value;
                    return value;
                }

                dictionary.Add(key, addValue);
                return addValue;
            }
        }

        public static TValue AddOrUpdate<TKey, TValue>(this ISynchronizedDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> addFactory, Func<TKey, TValue, TValue> updateFactory)
        {
            lock (dictionary)
            {
                if (dictionary.TryGetValue(key, out var value))
                {
                    value = updateFactory(key, value);
                    dictionary[key] = value;
                    return value;
                }

                value = addFactory(key);
                dictionary.Add(key, value);
                return value;
            }
        }

        public static TValue AddOrUpdate<TKey, TValue, TState>(this ISynchronizedDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TState, TValue> addFactory, Func<TKey, TState, TValue, TValue> updateFactory, TState state)
        {
            lock (dictionary)
            {
                if (dictionary.TryGetValue(key, out var value))
                {
                    value = updateFactory(key, state, value);
                    dictionary[key] = value;
                    return value;
                }

                value = addFactory(key, state);
                dictionary.Add(key, value);
                return value;
            }
        }
    }
}
