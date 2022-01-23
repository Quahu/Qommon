using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Qommon.Collections
{
    /// <summary>
    ///     Represents extension methods for lists.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ListExtensions
    {
        /// <summary>
        ///     Adds the specified items to this list.
        /// </summary>
        /// <param name="list"> The list to add the items to. </param>
        /// <param name="items"> The items to add to the list. </param>
        /// <typeparam name="T"> The type of the list items. </typeparam>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="list"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <paramref name="items"/> is <see langword="null"/>.
        /// </exception>
        public static void AddRange<T>(this IList<T> list, IEnumerable<T> items)
        {
            Guard.IsNotNull(list);

            if (list is List<T> stdList)
            {
                stdList.AddRange(items);
                return;
            }

            Guard.IsNotNull(items);

            if (list == items)
            {
                var array = items.ToArray();
                foreach (var item in array)
                    list.Add(item);
            }
            else
            {
                foreach (var item in items)
                    list.Add(item);
            }
        }

#if NET6_0_OR_GREATER
        /// <summary>
        ///     Shuffles the items of this list.
        /// </summary>
        /// <param name="list"> The list to shuffle. </param>
        /// <typeparam name="T"> The type of the list items. </typeparam>
        public static void Shuffle<T>(this IList<T> list)
            => list.Shuffle(Random.Shared);
#endif

        /// <summary>
        ///     Shuffles the items of this list using the specified <see cref="Random"/> instance.
        /// </summary>
        /// <param name="list"> The list to shuffle. </param>
        /// <param name="random"> The <see cref="Random"/> instance to use. </param>
        /// <typeparam name="T"> The type of the list items. </typeparam>
        public static void Shuffle<T>(this IList<T> list, Random random)
        {
            Guard.IsNotNull(list);
            Guard.IsNotNull(random);

            var count = list.Count;
            if (count < 2)
                return;

            for (var i = 0; i < count - 1; i++)
            {
                var j = random.Next(i, count);
                var temp = list[j];
                list[j] = list[i];
                list[i] = temp;
            }
        }
    }
}
