using Qommon.Collections.Synchronized;

namespace Qommon.Metadata.Dynamic
{
    public static partial class DynamicMetadata
    {
        private class SynchronizedMetadataImpl : ISynchronizedMetadata
        {
            public ISynchronizedDictionary<string, object?>? Metadata { get; set; }

            public SynchronizedMetadataImpl(ISynchronizedDictionary<string, object?>? dictionary)
            {
                Metadata = dictionary;
            }
        }

        /// <summary>
        ///     Sets a metadata dictionary for the given instance.
        ///     If <paramref name="instance"/> implements <see cref="IMetadata"/> the <see cref="IMetadata.Metadata"/> property is set.
        ///     Otherwise an internal implementation wraps the dictionary and is weakly attached to <paramref name="instance"/>.
        /// </summary>
        /// <param name="instance"> The instance to set the metadata for. </param>
        /// <param name="dictionary"> The metadata dictionary to set. </param>
        /// <returns>
        ///     The <see cref="IMetadata"/> implementation.
        /// </returns>
        public static ISynchronizedMetadata SetSynchronized(object instance, ISynchronizedDictionary<string, object?>? dictionary)
        {
            if (instance is ISynchronizedMetadata synchronizedMetadata)
            {
                synchronizedMetadata.Metadata = dictionary;
                return synchronizedMetadata;
            }

            if (Cache.TryGetValue(instance, out var metadata) && (synchronizedMetadata = (metadata as ISynchronizedMetadata)!) != null)
            {
                synchronizedMetadata.Metadata = dictionary;
                return synchronizedMetadata;
            }

            synchronizedMetadata = new SynchronizedMetadataImpl(dictionary);
            Cache.AddOrUpdate(instance, synchronizedMetadata);
            return synchronizedMetadata;
        }

        /// <summary>
        ///     Gets or sets a metadata object for the given instance.
        ///     If <paramref name="instance"/> implements <see cref="IMetadata"/>, it is returned directly.
        ///     If an internal implementation has been attached using <see cref="SetSynchronized(object,Qommon.Collections.Synchronized.ISynchronizedDictionary{string,object})"/>, it is returned.
        ///     Otherwise, it is called with a new synchronized dictionary.
        /// </summary>
        /// <remarks>
        ///     This methods preserves the non-synchronized metadata, if such exists.
        /// </remarks>
        /// <param name="instance"> The instance to get the metadata for. </param>
        /// <returns>
        ///     The <see cref="IMetadata"/> implementation.
        /// </returns>
        public static ISynchronizedMetadata GetOrCreateSynchronized(object instance)
        {
            if (instance is ISynchronizedMetadata synchronizedMetadata)
                return synchronizedMetadata;

            if (Cache.TryGetValue(instance, out var metadata) && (synchronizedMetadata = (metadata as ISynchronizedMetadata)!) != null)
                return synchronizedMetadata;

            return SetSynchronized(instance, metadata?.Metadata != null
                ? new SynchronizedDictionary<string, object?>(metadata.Metadata)
                : new SynchronizedDictionary<string, object?>());
        }

        /// <summary>
        ///     Sets a metadata dictionary for the given instance.
        ///     An internal implementation wraps the dictionary and is weakly attached to <paramref name="instance"/>.
        /// </summary>
        /// <param name="instance"> The instance to set the metadata for. </param>
        /// <param name="dictionary"> The metadata dictionary to set. </param>
        /// <returns>
        ///     The <see cref="IMetadata"/> implementation.
        /// </returns>
        public static ISynchronizedMetadata SetSynchronized(ISynchronizedMetadata instance, ISynchronizedDictionary<string, object?>? dictionary)
        {
            if (Cache.TryGetValue(instance, out var metadata) && metadata is ISynchronizedMetadata synchronizedMetadata)
            {
                synchronizedMetadata.Metadata = dictionary;
                return synchronizedMetadata;
            }

            synchronizedMetadata = new SynchronizedMetadataImpl(dictionary);
            Cache.AddOrUpdate(instance, synchronizedMetadata);
            return synchronizedMetadata;
        }

        /// <summary>
        ///     Gets or sets a metadata object for the given instance.
        ///     If an internal implementation has been attached using <see cref="SetSynchronized(ISynchronizedMetadata,Qommon.Collections.Synchronized.ISynchronizedDictionary{string,object})"/>, it is returned.
        ///     Otherwise, it is called with a new synchronized dictionary.
        /// </summary>
        /// <remarks>
        ///     This methods preserves the non-synchronized metadata, if such exists.
        /// </remarks>
        /// <param name="instance"> The instance to get the metadata for. </param>
        /// <returns>
        ///     The <see cref="IMetadata"/> implementation.
        /// </returns>
        public static ISynchronizedMetadata GetOrCreateSynchronized(ISynchronizedMetadata instance)
        {
            if (Cache.TryGetValue(instance, out var metadata) && metadata is ISynchronizedMetadata synchronizedMetadata)
                return synchronizedMetadata;

            return SetSynchronized(instance, metadata?.Metadata != null
                ? new SynchronizedDictionary<string, object?>(metadata.Metadata)
                : new SynchronizedDictionary<string, object?>());
        }
    }
}
