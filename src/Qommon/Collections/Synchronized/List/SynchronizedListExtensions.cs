using System.ComponentModel;

namespace Qommon.Collections.Synchronized
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class SynchronizedListExtensions
    {
        public static T[] ToArray<T>(this ISynchronizedList<T> list)
        {
            lock (list)
            {
                var array = new T[list.Count];
                list.CopyTo(array, 0);
                return array;
            }
        }
    }
}
