using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Qommon.Collections.ReadOnly;

/// <summary>
///     Represents collection extensions for creating read-only collections.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public static class ReadOnlyCollectionExtensions
{
    /// <summary>
    ///     Wraps this collection in a <see cref="ReadOnlyCollection{T}"/> which prevents its modification.
    /// </summary>
    /// <param name="collection"> The collection to wrap. </param>
    /// <typeparam name="T"> The type of the items. </typeparam>
    /// <returns>
    ///     A read-only collection wrapper.
    /// </returns>
    public static IReadOnlyCollection<T> ReadOnly<T>(this ICollection<T> collection)
    {
        return new ReadOnlyCollection<T>(collection);
    }

    /// <summary>
    ///     Wraps this list in a <see cref="ReadOnlyList{T}"/> which prevents its modification.
    /// </summary>
    /// <param name="list"> The list to wrap. </param>
    /// <typeparam name="T"> The type of the items. </typeparam>
    /// <returns>
    ///     A read-only list wrapper.
    /// </returns>
    public static IReadOnlyList<T> ReadOnly<T>(this IList<T> list)
    {
        return new ReadOnlyList<T>(list);
    }

    /// <summary>
    ///     Wraps this dictionary in a <see cref="ReadOnlyDictionary{TKey,TValue}"/> which prevents its modification.
    /// </summary>
    /// <param name="dictionary"> The dictionary to wrap. </param>
    /// <typeparam name="TKey"> The type of the keys. </typeparam>
    /// <typeparam name="TValue"> The type of the values. </typeparam>
    /// <returns>
    ///     A read-only dictionary wrapper.
    /// </returns>
    public static IReadOnlyDictionary<TKey, TValue> ReadOnly<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        where TKey : notnull
    {
        return new ReadOnlyDictionary<TKey, TValue>(dictionary);
    }

    /// <summary>
    ///     Wraps this list in a <see cref="ReadOnlySet{T}"/> which prevents its modification.
    /// </summary>
    /// <param name="set"> The set to wrap. </param>
    /// <typeparam name="T"> The type of the items. </typeparam>
    /// <returns>
    ///     A read-only set wrapper.
    /// </returns>
    public static IReadOnlySet<T> ReadOnly<T>(this ISet<T> set)
    {
        return new ReadOnlySet<T>(set);
    }

    /// <summary>
    ///     Copies the items of this enumerable into a new <see cref="ReadOnlyList{T}"/>.
    /// </summary>
    /// <param name="source"> The enumerable to create the list from. </param>
    /// <typeparam name="T"> The type of the items. </typeparam>
    /// <returns>
    ///     A read-only list.
    /// </returns>
    public static IReadOnlyList<T> ToReadOnlyList<T>(this IEnumerable<T> source)
    {
        return source.ToArray().ReadOnly();
    }

    /// <summary>
    ///     Copies the items of this list into a new <see cref="ReadOnlyList{T}"/>.
    ///     Projects the source items using the provided selector.
    /// </summary>
    /// <param name="source"> The list to create the list from. </param>
    /// <param name="selector"> The projection called for each item. </param>
    /// <typeparam name="TSource"> The source type of the items. </typeparam>
    /// <typeparam name="TResult"> The type of the items returned from the selector. </typeparam>
    /// <returns>
    ///     A read-only list.
    /// </returns>
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

    /// <summary>
    ///     Copies the items of this list into a new <see cref="ReadOnlyList{T}"/>.
    ///     Projects the source items using the provided selector.
    /// </summary>
    /// <param name="source"> The list to create the list from. </param>
    /// <param name="state"> The state argument passed to the provided selector. </param>
    /// <param name="selector"> The projection called for each item. </param>
    /// <typeparam name="TSource"> The source type of the items. </typeparam>
    /// <typeparam name="TState"> The type of the state argument. </typeparam>
    /// <typeparam name="TResult"> The projected type of the items. </typeparam>
    /// <returns>
    ///     A read-only list.
    /// </returns>
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

    /// <summary>
    ///     Copies the key/value pairs of this enumerable into a new <see cref="ReadOnlyDictionary{TKey,TValue}"/>.
    /// </summary>
    /// <param name="source"> The enumerable to create the dictionary from. </param>
    /// <param name="comparer"> The key comparer to to use for the dictionary. </param>
    /// <typeparam name="TKey"> The type of the keys. </typeparam>
    /// <typeparam name="TValue"> The type of the values. </typeparam>
    /// <returns>
    ///     A read-only dictionary.
    /// </returns>
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

    /// <summary>
    ///     Copies the items of this enumerable into a new <see cref="ReadOnlyDictionary{TKey,TValue}"/>.
    ///     Projects the items into keys and values using the provided selectors.
    /// </summary>
    /// <param name="source"> The enumerable to create the dictionary from. </param>
    /// <param name="keySelector"> The key projection called for each item. </param>
    /// <param name="valueSelector"> The value projection called for each item. </param>
    /// <param name="comparer"> The key comparer to to use for the dictionary. </param>
    /// <typeparam name="TSource"> The source type of the items. </typeparam>
    /// <typeparam name="TKey"> The projected type of the keys. </typeparam>
    /// <typeparam name="TValue"> The projected type of the values. </typeparam>
    /// <returns>
    ///     A read-only dictionary.
    /// </returns>
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

    /// <summary>
    ///     Copies the items of this enumerable into a new <see cref="ReadOnlyDictionary{TKey,TValue}"/>.
    ///     Projects the items into keys and values using the provided selectors.
    /// </summary>
    /// <param name="source"> The enumerable to create the dictionary from. </param>
    /// <param name="state"> The state argument passed to the provided selectors. </param>
    /// <param name="keySelector"> The key projection called for each item. </param>
    /// <param name="valueSelector"> The value projection called for each item. </param>
    /// <param name="comparer"> The key comparer to to use for the dictionary. </param>
    /// <typeparam name="TSource"> The source type of the items. </typeparam>
    /// <typeparam name="TKey"> The projected type of the keys. </typeparam>
    /// <typeparam name="TValue"> The projected type of the values. </typeparam>
    /// <typeparam name="TState"> The type of the state argument. </typeparam>
    /// <returns>
    ///     A read-only dictionary.
    /// </returns>
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

    /// <summary>
    ///     Copies the items of this enumerable into a new <see cref="ReadOnlySet{T}"/>.
    /// </summary>
    /// <param name="source"> The enumerable to create the set from. </param>
    /// <typeparam name="T"> The type of the items. </typeparam>
    /// <returns>
    ///     A read-only set.
    /// </returns>
    public static IReadOnlySet<T> ToReadOnlyHashSet<T>(this IEnumerable<T> source)
    {
        return source.ToHashSet().ReadOnly();
    }
}
