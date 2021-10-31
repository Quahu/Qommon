using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Qommon.Collections
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class EnumerableExtensions
    {
        /// <summary>
        ///     Returns an array for this enumerable.
        ///     If the source is <see langword="null"/> an empty array is returned.
        ///     If the source is already an array it is returned directly.
        ///     Otherwise the source is copied to a new array.
        /// </summary>
        /// <param name="source"> The enumerable to get </param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T[] GetArray<T>(this IEnumerable<T> source)
        {
            return source switch
            {
                null => Array.Empty<T>(),
                T[] array => array,
                _ => source.ToArray()
            };
        }

        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source,
            IEqualityComparer<TKey> comparer = null)
        {
            return new(source, comparer);
        }
    }
}
