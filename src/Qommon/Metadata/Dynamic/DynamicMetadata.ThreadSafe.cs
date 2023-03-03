using Qommon.Collections.ThreadSafe;

namespace Qommon.Metadata.Dynamic;

public static partial class DynamicMetadata
{
    private class ThreadSafeMetadataImpl : IThreadSafeMetadata
    {
        public IThreadSafeDictionary<string, object?>? Metadata { get; set; }

        public ThreadSafeMetadataImpl(IThreadSafeDictionary<string, object?>? dictionary)
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
    public static IThreadSafeMetadata SetThreadSafe(object instance, IThreadSafeDictionary<string, object?>? dictionary)
    {
        if (instance is IThreadSafeMetadata threadSafeMetadata)
        {
            threadSafeMetadata.Metadata = dictionary;
            return threadSafeMetadata;
        }

        if (Cache.TryGetValue(instance, out var metadata) && (threadSafeMetadata = (metadata as IThreadSafeMetadata)!) != null)
        {
            threadSafeMetadata.Metadata = dictionary;
            return threadSafeMetadata;
        }

        threadSafeMetadata = new ThreadSafeMetadataImpl(dictionary);
        Cache.AddOrUpdate(instance, threadSafeMetadata);
        return threadSafeMetadata;
    }

    /// <summary>
    ///     Gets or sets a metadata object for the given instance.
    ///     If <paramref name="instance"/> implements <see cref="IMetadata"/>, it is returned directly.
    ///     If an internal implementation has been attached using <see cref="SetThreadSafe(Qommon.Metadata.IThreadSafeMetadata,Qommon.Collections.ThreadSafe.IThreadSafeDictionary{string,object?}?)"/>, it is returned.
    ///     Otherwise, it is called with a new thread-safe dictionary.
    /// </summary>
    /// <remarks>
    ///     This methods preserves the original metadata, if such exists.
    /// </remarks>
    /// <param name="instance"> The instance to get the metadata for. </param>
    /// <returns>
    ///     The <see cref="IMetadata"/> implementation.
    /// </returns>
    public static IThreadSafeMetadata GetOrCreateThreadSafe(object instance)
    {
        if (instance is IThreadSafeMetadata threadSafeMetadata)
            return threadSafeMetadata;

        if (Cache.TryGetValue(instance, out var metadata) && (threadSafeMetadata = (metadata as IThreadSafeMetadata)!) != null)
            return threadSafeMetadata;

        return SetThreadSafe(instance, metadata?.Metadata != null
            ? ThreadSafeDictionary.Monitor.Wrap(metadata.Metadata)
            : ThreadSafeDictionary.Monitor.Create<string, object?>());
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
    public static IThreadSafeMetadata SetThreadSafe(IThreadSafeMetadata instance, IThreadSafeDictionary<string, object?>? dictionary)
    {
        if (Cache.TryGetValue(instance, out var metadata) && metadata is IThreadSafeMetadata threadSafeMetadata)
        {
            threadSafeMetadata.Metadata = dictionary;
            return threadSafeMetadata;
        }

        threadSafeMetadata = new ThreadSafeMetadataImpl(dictionary);
        Cache.AddOrUpdate(instance, threadSafeMetadata);
        return threadSafeMetadata;
    }

    /// <summary>
    ///     Gets or sets a metadata object for the given instance.
    ///     If an internal implementation has been attached using <see cref="SetThreadSafe(Qommon.Metadata.IThreadSafeMetadata,Qommon.Collections.ThreadSafe.IThreadSafeDictionary{string,object?}?)"/>, it is returned.
    ///     Otherwise, it is called with a new thread-safe dictionary.
    /// </summary>
    /// <remarks>
    ///     This methods preserves the original metadata, if such exists.
    /// </remarks>
    /// <param name="instance"> The instance to get the metadata for. </param>
    /// <returns>
    ///     The <see cref="IMetadata"/> implementation.
    /// </returns>
    public static IThreadSafeMetadata GetOrCreateThreadSafe(IThreadSafeMetadata instance)
    {
        if (Cache.TryGetValue(instance, out var metadata) && metadata is IThreadSafeMetadata threadSafeMetadata)
            return threadSafeMetadata;

        return SetThreadSafe(instance, metadata?.Metadata != null
            ? ThreadSafeDictionary.Monitor.Wrap(metadata.Metadata)
            : ThreadSafeDictionary.Monitor.Create<string, object?>());
    }
}
