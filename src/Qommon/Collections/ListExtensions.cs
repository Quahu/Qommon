using System.Collections.Generic;
using System.Linq;

namespace Qommon.Collections
{
    public static class ListExtensions
    {
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
                items = items.ToArray();

            foreach (var item in items)
                list.Add(item);
        }
    }
}
