using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Qommon.Metadata.Dynamic;

/// <summary>
///     Represents methods to manipulate metadata on objects dynamically
///     and allows for treating any object as an <see cref="IMetadata"/> implementation.
/// </summary>
public static partial class DynamicMetadata
{
    // This class is a bit messy - the methods are ordered by object instance parameters, then IMetadata.
    // The same order exists in the 'ThreadSafe' partial.
    // 1. Get()
    // 2. Set()
    // 3. Remove()
    // 4. GetOrSet()

    // The runtime cache of the metadata wrappers.
    private static readonly ConditionalWeakTable<object, IMetadata> Cache = new();

    private sealed class MetadataImpl : IMetadata
    {
        public IDictionary<string, object?>? Metadata { get; set; }

        public MetadataImpl(IDictionary<string, object?>? dictionary)
        {
            Metadata = dictionary;
        }
    }

    /// <summary>
    ///     Gets a metadata object for the given instance.
    ///     If <paramref name="instance"/> implements <see cref="IMetadata"/>, it is returned directly.
    ///     If an internal implementation has been attached using <see cref="Set(object,System.Collections.Generic.IDictionary{string,object})"/>, it is returned.
    ///     Otherwise, <see langword="null"/> is returned.
    /// </summary>
    /// <param name="instance"> The instance to get the metadata for. </param>
    /// <returns>
    ///     The <see cref="IMetadata"/> implementation or <see langword="null"/>.
    /// </returns>
    public static IMetadata? Get(object instance)
    {
        if (instance is IMetadata metadata)
            return metadata;

        if (Cache.TryGetValue(instance, out metadata!))
            return metadata;

        return null;
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
    public static IMetadata Set(object instance, IDictionary<string, object?>? dictionary)
    {
        if (instance is IMetadata metadata)
        {
            metadata.Metadata = dictionary;
            return metadata;
        }

        if (Cache.TryGetValue(instance, out metadata!))
        {
            metadata.Metadata = dictionary;
            return metadata;
        }

        metadata = new MetadataImpl(dictionary);
        Cache.AddOrUpdate(instance, metadata);
        return metadata;
    }

    /// <summary>
    ///     Removes a weakly attached metadata dictionary for the given instance that was set using <see cref="Set(object,System.Collections.Generic.IDictionary{string,object?}?)"/>.
    /// </summary>
    /// <param name="instance"> The instance to remove the metadata from. </param>
    /// <returns>
    ///     <see langword="true"/> if it was removed.
    /// </returns>
    public static bool Remove(object instance)
    {
        return Cache.Remove(instance);
    }

    /// <summary>
    ///     Gets or sets a metadata object for the given instance.
    ///     If <paramref name="instance"/> implements <see cref="IMetadata"/>, it is returned directly.
    ///     If an internal implementation has been attached using <see cref="Set(object,System.Collections.Generic.IDictionary{string,object})"/>, it is returned.
    ///     Otherwise, it is called with a new dictionary.
    /// </summary>
    /// <param name="instance"> The instance to get the metadata for. </param>
    /// <returns>
    ///     The <see cref="IMetadata"/> implementation.
    /// </returns>
    public static IMetadata GetOrCreate(object instance)
    {
        if (instance is IMetadata metadata)
            return metadata;

        if (Cache.TryGetValue(instance, out metadata!))
            return metadata;

        return Set(instance, new Dictionary<string, object?>());
    }

    /// <summary>
    ///     Gets a metadata object for the given instance.
    ///     If an internal implementation has been attached using <see cref="Set(IMetadata,System.Collections.Generic.IDictionary{string,object})"/>, it is returned.
    ///     Otherwise, <see langword="null"/> is returned.
    /// </summary>
    /// <param name="instance"> The instance to get the metadata for. </param>
    /// <returns>
    ///     The <see cref="IMetadata"/> implementation or <see langword="null"/>.
    /// </returns>
    public static IMetadata? Get(IMetadata instance)
    {
        if (Cache.TryGetValue(instance, out var metadata))
            return metadata;

        return null;
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
    public static IMetadata Set(IMetadata instance, IDictionary<string, object?>? dictionary)
    {
        if (Cache.TryGetValue(instance, out var metadata))
        {
            metadata.Metadata = dictionary;
            return metadata;
        }

        metadata = new MetadataImpl(dictionary);
        Cache.AddOrUpdate(instance, metadata);
        return metadata;
    }

    /// <summary>
    ///     Gets or sets a metadata object for the given instance.
    ///     If an internal implementation has been attached using <see cref="Set(IMetadata,System.Collections.Generic.IDictionary{string,object})"/>, it is returned.
    ///     Otherwise, it is called with a new dictionary.
    /// </summary>
    /// <param name="instance"> The instance to get the metadata for. </param>
    /// <returns>
    ///     The <see cref="IMetadata"/> implementation.
    /// </returns>
    public static IMetadata GetOrCreate(IMetadata instance)
    {
        if (Cache.TryGetValue(instance, out var metadata))
            return metadata;

        return Set(instance, new Dictionary<string, object?>());
    }
}
