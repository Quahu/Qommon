using System;
using System.Collections.Generic;
using System.Linq;

namespace Qommon.Collections
{
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
    }
}
