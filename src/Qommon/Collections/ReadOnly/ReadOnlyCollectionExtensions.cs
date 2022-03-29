using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Qommon.Collections.ReadOnly;

namespace Qommon.Collections
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ReadOnlyCollectionExtensions
    {
        public static IReadOnlyCollection<T> ReadOnly<T>(this ICollection<T> collection)
            => new ReadOnlyCollection<T>(collection);

        public static IReadOnlyList<T> ReadOnly<T>(this IList<T> list)
            => new ReadOnlyList<T>(list);

        public static IReadOnlyDictionary<TKey, TValue> ReadOnly<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
            where TKey : notnull
            => new ReadOnlyDictionary<TKey, TValue>(dictionary);

        public static IReadOnlySet<T> ReadOnly<T>(this ISet<T> set)
            => new ReadOnlySet<T>(set);

        public static IReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source,
            IEqualityComparer<TKey>? comparer = null)
            where TKey : notnull
        {
            Guard.IsNotNull(source);

            var dictionary = new Dictionary<TKey, TValue>(comparer);
            foreach (var kvp in source)
                dictionary.Add(kvp.Key, kvp.Value);

            return dictionary.ReadOnly();
        }

        public static IReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TSource, TKey, TValue>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector, Func<TSource, TValue> valueSelector, IEqualityComparer<TKey>? comparer = null)
            where TKey : notnull
        {
            Guard.IsNotNull(keySelector);
            Guard.IsNotNull(valueSelector);

            var dictionary = new Dictionary<TKey, TValue>(comparer);
            foreach (var item in source)
            {
                var key = keySelector(item);
                var value = valueSelector(item);
                dictionary.Add(key, value);
            }

            return dictionary.ReadOnly();
        }

        public static IReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TSource, TKey, TValue, TState>(this IEnumerable<TSource> source,
            TState state, Func<TSource, TState, TKey> keySelector, Func<TSource, TState, TValue> valueSelector, IEqualityComparer<TKey>? comparer = null)
            where TKey : notnull
        {
            Guard.IsNotNull(source);
            Guard.IsNotNull(keySelector);
            Guard.IsNotNull(valueSelector);

            var dictionary = new Dictionary<TKey, TValue>(comparer);
            foreach (var item in source)
            {
                var key = keySelector(item, state);
                var value = valueSelector(item, state);
                dictionary.Add(key, value);
            }

            return dictionary.ReadOnly();
        }

        public static IReadOnlyList<TResult> ToReadOnlyList<TSource, TResult>(this IList<TSource> source,
            Func<TSource, TResult> selector)
        {
            Guard.IsNotNull(source);
            Guard.IsNotNull(selector);

            var count = source.Count;
            var array = new TResult[count];
            for (var i = 0; i < count; i++)
            {
                var value = selector(source[i]);
                array[i] = value;
            }

            return array.ReadOnly();
        }

        public static IReadOnlyList<TResult> ToReadOnlyList<TSource, TState, TResult>(this IList<TSource> source,
            TState state, Func<TSource, TState, TResult> selector)
        {
            Guard.IsNotNull(source);
            Guard.IsNotNull(selector);

            var count = source.Count;
            var array = new TResult[count];
            for (var i = 0; i < count; i++)
            {
                var value = selector(source[i], state);
                array[i] = value;
            }

            return array.ReadOnly();
        }

        public static IReadOnlyList<T> ToReadOnlyList<T>(this IEnumerable<T> source)
            => source.ToArray().ReadOnly();

        public static IReadOnlySet<T> ToReadOnlyHashSet<T>(this IEnumerable<T> source)
            => source.ToHashSet().ReadOnly();
    }
}
