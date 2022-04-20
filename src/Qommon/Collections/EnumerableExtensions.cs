using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Qommon.Collections
{
    /// <summary>
    ///     Represents extensions for enumerables.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class EnumerableExtensions
    {
        /// <inheritdoc cref="GetArray"/>
        /// <typeparam name="T"> The type of the elements. </typeparam>
        public static T[] GetArray<T>(this IEnumerable<T>? source)
        {
            return source switch
            {
                null => Array.Empty<T>(),
                T[] array => array,
                _ => source.ToArray()
            };
        }

        /// <summary>
        ///     Returns an array for this enumerable.
        /// </summary>
        /// <remarks>
        ///     If the source is <see langword="null"/> an empty array is returned.
        ///     If the source is already an array it is returned directly.
        ///     Otherwise the source is copied to a new array.
        /// </remarks>
        /// <param name="source"> The enumerable to get the array for. </param>
        /// <returns>
        ///     An array containing the elements from the enumerable.
        /// </returns>
        public static object[] GetArray(this IEnumerable? source)
        {
            if (source == null)
                return Array.Empty<object>();

            if (source is IEnumerable<object> genericSource)
                return genericSource.GetArray();

            return source.Cast<object>().GetArray();
        }

        /// <summary>
        ///     Returns a new <see cref="Dictionary{TKey,TValue}"/> created from this enumerable.
        /// </summary>
        /// <param name="source"> The enumerable to create a dictionary from. </param>
        /// <param name="comparer"> The key comparer to use for the dictionary. </param>
        /// <typeparam name="TKey"> The type of keys. </typeparam>
        /// <typeparam name="TValue"> The type of values. </typeparam>
        /// <returns>
        ///     A new <see cref="Dictionary{TKey,TValue}"/>.
        /// </returns>
        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source, IEqualityComparer<TKey>? comparer = null)
            where TKey : notnull
        {
            return new(source, comparer);
        }
    }
}
