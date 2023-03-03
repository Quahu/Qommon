using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Qommon.Collections.ThreadSafe;

/// <summary>
///     Represents methods for creating <see cref="ThreadSafeDictionary{TKey,TValue}"/> instances.
///     The subtypes represent the different built-in implementations.
/// </summary>
public static class ThreadSafeDictionary
{
    /// <summary>
    ///     Represents methods for creating <see cref="ThreadSafeDictionary{TKey,TValue}"/> instances
    ///     that use <see cref="System.Threading.Monitor"/> for synchronization.
    /// </summary>
    public static class Monitor
    {
        /// <summary>
        ///     Wraps an existing dictionary in a <see cref="ThreadSafeDictionary{TKey,TValue}"/>.
        ///     The returned dictionary provides a thread-safe access to the wrapped dictionary.
        /// </summary>
        /// <remarks>
        ///     Accessing the wrapped dictionary directly without using the
        ///     wrapper <see cref="ThreadSafeDictionary{TKey,TValue}"/> will remain not thread-safe.
        /// </remarks>
        /// <param name="dictionary"> The dictionary to wrap. </param>
        /// <typeparam name="TKey"> The type of keys. </typeparam>
        /// <typeparam name="TValue"> The type of values. </typeparam>
        /// <returns>
        ///     The <see cref="ThreadSafeDictionary{TKey,TValue}"/> wrapper.
        /// </returns>
        public static ThreadSafeDictionary<TKey, TValue> Wrap<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
            where TKey : notnull
        {
            return new MonitorThreadSafeDictionary<TKey, TValue>(dictionary);
        }

        public static ThreadSafeDictionary<TKey, TValue> Create<TKey, TValue>(IEqualityComparer<TKey>? comparer = null)
            where TKey : notnull
        {
            return Wrap(new Dictionary<TKey, TValue>(comparer));
        }

        public static ThreadSafeDictionary<TKey, TValue> Create<TKey, TValue>(int capacity, IEqualityComparer<TKey>? comparer = null)
            where TKey : notnull
        {
            return Wrap(new Dictionary<TKey, TValue>(capacity, comparer));
        }

        public static ThreadSafeDictionary<TKey, TValue> Create<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> collection, IEqualityComparer<TKey>? comparer = null)
            where TKey : notnull
        {
            return Wrap(new Dictionary<TKey, TValue>(collection, comparer));
        }
    }

    /// <summary>
    ///     Represents methods for creating <see cref="ThreadSafeDictionary{TKey,TValue}"/> instances
    ///     that use <see cref="ConcurrentDictionary{TKey,TValue}"/> for synchronization.
    /// </summary>
    /// <remarks>
    ///     Using this implementation has the downside
    ///     of introducing a small overhead over just using <see cref="ConcurrentDictionary{TKey,TValue}"/>
    ///     directly, but has the upside of sharing the common base type <see cref="ThreadSafeDictionary{TKey,TValue}"/>.
    /// </remarks>
    public static class ConcurrentDictionary
    {
        /// <summary>
        ///     Wraps an existing dictionary in a <see cref="ThreadSafeDictionary{TKey,TValue}"/>.
        /// </summary>
        /// <param name="dictionary"> The dictionary to wrap. </param>
        /// <typeparam name="TKey"> The type of keys. </typeparam>
        /// <typeparam name="TValue"> The type of values. </typeparam>
        /// <returns>
        ///     The <see cref="ThreadSafeDictionary{TKey,TValue}"/> wrapper.
        /// </returns>
        public static ThreadSafeDictionary<TKey, TValue> Wrap<TKey, TValue>(ConcurrentDictionary<TKey, TValue> dictionary)
            where TKey : notnull
        {
            return new ConcurrentThreadSafeDictionary<TKey, TValue>(dictionary);
        }

        public static ThreadSafeDictionary<TKey, TValue> Create<TKey, TValue>(IEqualityComparer<TKey>? comparer = null)
            where TKey : notnull
        {
            return Wrap(new ConcurrentDictionary<TKey, TValue>(comparer));
        }

        public static ThreadSafeDictionary<TKey, TValue> Create<TKey, TValue>(int concurrencyLevel, int capacity, IEqualityComparer<TKey>? comparer = null)
            where TKey : notnull
        {
            return Wrap(new ConcurrentDictionary<TKey, TValue>(concurrencyLevel, capacity, comparer));
        }

        public static ThreadSafeDictionary<TKey, TValue> Create<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> collection, IEqualityComparer<TKey>? comparer = null)
            where TKey : notnull
        {
            return Wrap(new ConcurrentDictionary<TKey, TValue>(collection, comparer));
        }

        public static ThreadSafeDictionary<TKey, TValue> Create<TKey, TValue>(int concurrencyLevel, IEnumerable<KeyValuePair<TKey, TValue>> collection, IEqualityComparer<TKey>? comparer = null)
            where TKey : notnull
        {
            return Wrap(new ConcurrentDictionary<TKey, TValue>(concurrencyLevel, collection, comparer));
        }
    }
}
