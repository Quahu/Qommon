using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Qommon.Collections;
using Qommon.Collections.ThreadSafe;

namespace Qommon.Metadata;

/// <summary>
///     Represents metadata extension methods.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public static class MetadataExtensions
{
    /// <summary>
    ///     Gets a metadata value associated with the specified key.
    /// </summary>
    /// <param name="metadata"> The metadata object. </param>
    /// <param name="key"> The key whose value to get. </param>
    /// <param name="value"> The metadata value. </param>
    /// <returns>
    ///     <see langword="true"/> if the key was found.
    /// </returns>
    public static bool TryGetMetadata(this IMetadata metadata, string key, out object? value)
    {
        Guard.IsNotNull(metadata);
        Guard.IsNotNull(key);

        var dictionary = metadata.Metadata;
        if (dictionary == null)
        {
            value = null;
            return false;
        }

        return dictionary.TryGetValue(key, out value);
    }

    /// <summary>
    ///     Gets a metadata value associated with the specified key
    ///     and attempts to cast/convert it to the specified type.
    /// </summary>
    /// <typeparam name="T"> The type to cast/convert to. </typeparam>
    /// <param name="metadata"> The metadata object. </param>
    /// <param name="key"> The key whose value to get. </param>
    /// <param name="provider">
    ///     The format provider to be used if the value is <see cref="IConvertible"/>
    ///     and conversion to <typeparamref name="T"/> is necessary.
    /// </param>
    /// <returns>
    ///     <see langword="true"/> if the key was found and was successfully casted/converted to <typeparamref name="T"/>.
    /// </returns>
    public static T? GetMetadata<T>(this IMetadata metadata, string key, IFormatProvider? provider = null)
    {
        Guard.IsNotNull(metadata);
        Guard.IsNotNull(key);

        if (metadata.TryGetMetadata(key, out var rawValue))
        {
            if (rawValue is null)
            {
                if (typeof(T).TryGetNullableUnderlyingType(out _))
                    return default;

                if (!typeof(T).IsValueType)
                    return default;

                Throw.ArgumentException("The type parameter is not nullable and the returned metadata value is null.", nameof(T));
            }
            else if (rawValue is T tValue)
            {
                return tValue;
            }
            else if (rawValue is IConvertible)
            {
                try
                {
                    return (T) Convert.ChangeType(rawValue, Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T), provider);
                }
                catch (Exception ex)
                {
                    Throw.ArgumentException("Failed to convert the metadata value to the type parameter.", nameof(T), ex);
                }
            }
        }

        return Throw.ArgumentException<T>("The key was not found in the metadata.", nameof(key));
    }

    /// <summary>
    ///     Gets a metadata value associated with the specified key
    ///     and attempts to cast/convert it to the specified type.
    /// </summary>
    /// <typeparam name="T"> The type to cast/convert to. </typeparam>
    /// <param name="metadata"> The metadata object. </param>
    /// <param name="key"> The key whose value to get. </param>
    /// <param name="value"> The metadata value. </param>
    /// <param name="provider">
    ///     The format provider to be used if the value is <see cref="IConvertible"/>
    ///     and conversion to <typeparamref name="T"/> is necessary.
    /// </param>
    /// <returns>
    ///     <see langword="true"/> if the key was found and was successfully casted/converted to <typeparamref name="T"/>.
    /// </returns>
    public static bool TryGetMetadata<T>(this IMetadata metadata, string key, out T? value, IFormatProvider? provider = null)
    {
        Guard.IsNotNull(metadata);
        Guard.IsNotNull(key);

        if (metadata.TryGetMetadata(key, out var rawValue))
        {
            if (rawValue is null)
            {
                if (typeof(T).TryGetNullableUnderlyingType(out _))
                {
                    value = default!;
                    return true;
                }

                if (!typeof(T).IsValueType)
                {
                    value = default!;
                    return true;
                }
            }
            else if (rawValue is T tValue)
            {
                value = tValue;
                return true;
            }
            else if (rawValue is IConvertible)
            {
                try
                {
                    value = (T) Convert.ChangeType(rawValue, Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T), provider);
                    return true;
                }
                catch { }
            }
        }

        value = default!;
        return false;
    }

    /// <summary>
    ///     Gets a metadata value associated with the specified key
    ///     and attempts to cast/convert it to the specified type.
    ///     If the value is not found or the conversion fails the <paramref name="defaultValue"/> is returned.
    /// </summary>
    /// <typeparam name="T"> The type to cast/convert to. </typeparam>
    /// <param name="metadata"> The metadata object. </param>
    /// <param name="key"> The key whose value to get. </param>
    /// <param name="defaultValue"> The value to fall back onto. </param>
    /// <param name="provider">
    ///     The format provider to be used if the value is <see cref="IConvertible"/>
    ///     and conversion to <typeparamref name="T"/> is necessary.
    /// </param>
    /// <returns>
    ///     The metadata value if the key was found and was successfully casted/converted to <typeparamref name="T"/> or the <paramref name="defaultValue"/>.
    /// </returns>
    public static T? GetMetadataOrDefault<T>(this IMetadata metadata, string key, T? defaultValue = default!, IFormatProvider? provider = null)
    {
        Guard.IsNotNull(metadata);
        Guard.IsNotNull(key);

        if (metadata.TryGetMetadata<T>(key, out var value, provider))
            return value;

        return defaultValue;
    }

    /// <summary>
    ///     Sets a metadata value for the specified key.
    /// </summary>
    /// <param name="metadata"> The metadata object. </param>
    /// <param name="key"> The key whose value to set. </param>
    /// <param name="value"> The metadata value. </param>
    /// <exception cref="ArgumentException">
    ///     Thrown when the metadata dictionary is <see langword="null"/> or read-only.
    /// </exception>
    public static void SetMetadata(this IMetadata metadata, string key, object? value)
    {
        Guard.IsNotNull(metadata);
        Guard.IsNotNull(key);

        var dictionary = metadata.Metadata;
        if (dictionary == null || dictionary.IsReadOnly)
            Throw.ArgumentException("The metadata dictionary is not writable.", nameof(metadata));

        dictionary[key] = value;
    }

    /// <summary>
    ///     Sets a metadata value for the specified key.
    /// </summary>
    /// <param name="metadata"> The metadata object. </param>
    /// <param name="key"> The key whose value to set. </param>
    /// <param name="value"> The metadata value. </param>
    /// <returns>
    ///     <see langword="true"/> if the metadata dictionary is writable.
    /// </returns>
    public static bool TrySetMetadata(this IMetadata metadata, string key, object? value)
    {
        Guard.IsNotNull(metadata);
        Guard.IsNotNull(key);

        var dictionary = metadata.Metadata;
        if (dictionary == null || dictionary.IsReadOnly)
            return false;

        dictionary[key] = value;
        return true;
    }

    /// <summary>
    ///     Removes a metadata value associated with the specified key.
    /// </summary>
    /// <param name="metadata"> The metadata object. </param>
    /// <param name="key"> The key whose value to get. </param>
    /// <returns>
    ///     <see langword="true"/> if the key was found.
    /// </returns>
    public static bool RemoveMetadata(this IMetadata metadata, string key)
    {
        Guard.IsNotNull(metadata);
        Guard.IsNotNull(key);

        var dictionary = metadata.Metadata;
        if (dictionary == null || dictionary.IsReadOnly)
            return false;

        return dictionary.Remove(key);
    }

    /// <summary>
    ///     Removes a metadata value associated with the specified key.
    /// </summary>
    /// <param name="metadata"> The metadata object. </param>
    /// <param name="key"> The key whose value to get. </param>
    /// <param name="value"> The metadata value. </param>
    /// <returns>
    ///     <see langword="true"/> if the key was found.
    /// </returns>
    public static bool TryRemoveMetadata(this IMetadata metadata, string key, out object? value)
    {
        Guard.IsNotNull(metadata);
        Guard.IsNotNull(key);

        var dictionary = metadata.Metadata;
        if (dictionary == null || dictionary.IsReadOnly)
        {
            value = null;
            return false;
        }

        // Thread-safe access.
        if (dictionary is IThreadSafeDictionary<string, object?> threadSafeDictionary)
            return threadSafeDictionary.TryRemove(key, out value);

        return dictionary.Remove(key, out value);
    }

    /// <summary>
    ///     Enumerates the metadata items.
    /// </summary>
    /// <param name="metadata"> The metadata object. </param>
    /// <returns>
    ///     An enumerable of metadata items or an empty enumerable if the metadata dictionary is <see langword="null"/>.
    /// </returns>
    public static IEnumerable<KeyValuePair<string, object?>> EnumerateMetadata(this IMetadata metadata)
    {
        Guard.IsNotNull(metadata);

        var dictionary = metadata.Metadata;
        if (dictionary == null)
            return Enumerable.Empty<KeyValuePair<string, object?>>();

        return dictionary;
    }

    /// <summary>
    ///     Puts the metadata items into a separate dictionary.
    /// </summary>
    /// <param name="metadata"> The metadata object. </param>
    /// <param name="comparer"> The comparer for the dictionary to use. </param>
    /// <returns>
    ///     A dictionary of metadata items or an empty dictionary if the metadata dictionary is <see langword="null"/>.
    /// </returns>
    public static Dictionary<string, object?> ToMetadataDictionary(this IMetadata metadata, IEqualityComparer<string>? comparer = null)
    {
        Guard.IsNotNull(metadata);

        var dictionary = metadata.Metadata;
        if (dictionary == null)
            return new Dictionary<string, object?>();

        return dictionary.ToDictionary(comparer);
    }

    /// <summary>
    ///     Copies metadata items from this metadata to another.
    /// </summary>
    /// <remarks>
    ///     If this metadata is thread-safe the target's metadata will be made thread-safe as well.
    /// </remarks>
    /// <param name="metadata"> The metadata object. </param>
    /// <param name="target"> The target metadata object. </param>
    public static void CopyMetadataTo(this IMetadata metadata, IMetadata target)
    {
        Guard.IsNotNull(metadata);
        Guard.IsNotNull(target);

        var dictionary = target.EnsureMetadataDictionaryExists();
        metadata.CopyMetadataTo(dictionary);
    }

    /// <summary>
    ///     Copies metadata items from this metadata to another.
    /// </summary>
    /// <remarks>
    ///     If this metadata is thread-safe the target's metadata will be made thread-safe as well.
    /// </remarks>
    /// <param name="metadata"> The metadata object. </param>
    /// <param name="target"> The target metadata object. </param>
    public static void CopyMetadataTo(this IMetadata metadata, IDictionary<string, object?> target)
    {
        Guard.IsNotNull(metadata);
        Guard.IsNotNull(target);

        var items = metadata.Metadata as IEnumerable<KeyValuePair<string, object?>>;
        if (items == null)
            return;

        if (items is IThreadSafeDictionary<string, object?> threadSafeDictionary)
            items = threadSafeDictionary.ToArray();

        foreach (var (key, value) in items)
        {
            target[key] = value;
        }
    }

    /// <summary>
    ///     Ensures that this metadata has a dictionary set.
    /// </summary>
    /// <param name="metadata"> The metadata object. </param>
    /// <returns>
    ///     A dictionary of metadata items.
    /// </returns>
    public static IDictionary<string, object?> EnsureMetadataDictionaryExists(this IMetadata metadata)
    {
        Guard.IsNotNull(metadata);

        var dictionary = metadata.Metadata;
        if (dictionary != null)
            return dictionary;

        if (metadata is IThreadSafeMetadata)
            return metadata.EnsureThreadSafeMetadataDictionaryExists();

        dictionary = new Dictionary<string, object?>();
        metadata.Metadata = dictionary;
        return dictionary;
    }

    /// <summary>
    ///     Ensures that this metadata has a thread-safe dictionary set.
    /// </summary>
    /// <param name="metadata"> The metadata object. </param>
    /// <returns>
    ///     A dictionary of metadata items.
    /// </returns>
    public static IThreadSafeDictionary<string, object?> EnsureThreadSafeMetadataDictionaryExists(this IMetadata metadata)
    {
        Guard.IsNotNull(metadata);

        IThreadSafeDictionary<string, object?> threadSafeDictionary;
        var dictionary = metadata.Metadata;
        if (dictionary != null)
        {
            // Checks if the dictionary is already thread-safe.
            if (dictionary is IThreadSafeDictionary<string, object?> existingThreadSafeDictionary)
                return existingThreadSafeDictionary;

            threadSafeDictionary = ThreadSafeDictionary.Monitor.Wrap(dictionary);
        }
        else
        {
            threadSafeDictionary = ThreadSafeDictionary.Monitor.Create<string, object?>();
        }

        metadata.Metadata = threadSafeDictionary;
        return threadSafeDictionary;
    }
}
