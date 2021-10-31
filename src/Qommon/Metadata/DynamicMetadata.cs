using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Qommon.Collections.Synchronized;

namespace Qommon
{
    /// <summary>
    ///     Represents methods to manipulate metadata on objects dynamically
    ///     and treat any given object as an <see cref="IMetadata"/> implementation.
    /// </summary>
    public static class DynamicMetadata
    {
        private class MetadataImpl : IMetadata
        {
            public IDictionary<string, object> Metadata { get; set; }

            public MetadataImpl(IDictionary<string, object> dictionary)
            {
                Metadata = dictionary;
            }
        }

        private static readonly ConditionalWeakTable<object, IMetadata> Cache = new();

        /// <summary>
        ///     Gets a metadata object for the given instance.
        ///     If <paramref name="instance"/> implements <see cref="IMetadata"/> it is returned directly.
        ///     If an internal implementation has been attached using <see cref="Set{T}"/> it is returned.
        ///     Otherwise <see langword="null"/> is returned.
        /// </summary>
        /// <typeparam name="T"> The type of the instance. Must be a reference type. </typeparam>
        /// <param name="instance"> The instance to get the metadata for. </param>
        /// <returns>
        ///     The <see cref="IMetadata"/> implementation or <see langword="null"/>.
        /// </returns>
        public static IMetadata Get<T>(T instance)
            where T : class
        {
            if (instance is IMetadata metadata)
                return metadata;

            if (Cache.TryGetValue(instance, out metadata))
                return metadata;

            return null;
        }

        /// <summary>
        ///     Gets or sets a metadata object for the given instance.
        ///     If <paramref name="instance"/> implements <see cref="IMetadata"/> it is returned directly.
        ///     If an internal implementation has been attached using <see cref="Set{T}"/> it is returned.
        ///     Otherwise <see cref="Set{T}"/> is called with a new dictionary.
        /// </summary>
        /// <typeparam name="T"> The type of the instance. Must be a reference type. </typeparam>
        /// <param name="instance"> The instance to get the metadata for. </param>
        /// <returns>
        ///     The <see cref="IMetadata"/> implementation.
        /// </returns>
        public static IMetadata GetOrSet<T>(T instance)
            where T : class
        {
            if (instance is IMetadata metadata)
                return metadata;

            if (Cache.TryGetValue(instance, out metadata))
                return metadata;

            return Set(instance, new Dictionary<string, object>());
        }

        /// <summary>
        ///     Gets or sets a metadata object for the given instance.
        ///     If <paramref name="instance"/> implements <see cref="IMetadata"/> it is returned directly.
        ///     If an internal implementation has been attached using <see cref="Set{T}"/> it is returned.
        ///     Otherwise <see cref="Set{T}"/> is called with a new synchronized dictionary.
        /// </summary>
        /// <typeparam name="T"> The type of the instance. Must be a reference type. </typeparam>
        /// <param name="instance"> The instance to get the metadata for. </param>
        /// <returns>
        ///     The <see cref="IMetadata"/> implementation.
        /// </returns>
        public static IMetadata GetOrSetSynchronized<T>(T instance)
            where T : class
        {
            if (instance is IMetadata metadata)
                return metadata;

            if (Cache.TryGetValue(instance, out metadata))
                return metadata;

            return Set(instance, new SynchronizedDictionary<string, object>());
        }

        /// <summary>
        ///     Sets a metadata dictionary for the given instance.
        ///     If <paramref name="instance"/> implements <see cref="IMetadata"/> the <see cref="IMetadata.Metadata"/> property is set.
        ///     Otherwise an internal implementation wraps the dictionary and is weakly attached to <paramref name="instance"/>.
        /// </summary>
        /// <typeparam name="T"> The type of the instance. Must be a reference type. </typeparam>
        /// <param name="instance"> The instance to set the metadata for. </param>
        /// <param name="dictionary"> The metadata dictionary to set. </param>
        /// <returns>
        ///     The <see cref="IMetadata"/> implementation.
        /// </returns>
        public static IMetadata Set<T>(T instance, IDictionary<string, object> dictionary)
            where T : class
        {
            if (instance is IMetadata metadata)
            {
                metadata.Metadata = dictionary;
                return metadata;
            }

            if (Cache.TryGetValue(instance, out metadata))
            {
                metadata.Metadata = dictionary;
                return metadata;
            }

            metadata = new MetadataImpl(dictionary);
            Cache.AddOrUpdate(instance, metadata);
            return metadata;
        }

        /// <summary>
        ///     Removes a weakly attached metadata dictionary for the given instance that was set using <see cref="Set{T}"/>.
        /// </summary>
        /// <typeparam name="T"> The type of the instance. Must be a reference type. </typeparam>
        /// <param name="instance"> The instance to remove the metadata from. </param>
        /// <returns>
        ///     <see langword="true"/> if it was removed.
        /// </returns>
        public static bool Remove<T>(T instance)
            where T : class
        {
            if (instance is IMetadata metadata)
                return false;

            return Cache.Remove(instance);
        }
    }
}
