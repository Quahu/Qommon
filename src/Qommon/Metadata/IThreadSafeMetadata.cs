using System.Collections.Generic;
using Qommon.Collections.ThreadSafe;
using Qommon.Metadata.Dynamic;

namespace Qommon.Metadata;

/// <summary>
///     Represents a type that can have extra data attached to it via a thread-safe dictionary.
/// </summary>
/// <remarks>
///     This interface has a default implementation for the <see cref="Metadata"/>
///     property using <see cref="DynamicMetadata"/>.
/// </remarks>
public interface IThreadSafeMetadata : IMetadata
{
    /// <inheritdoc cref="IMetadata.Metadata"/>
    new IThreadSafeDictionary<string, object?>? Metadata
    {
        get => DynamicMetadata.GetOrCreateThreadSafe(this).Metadata;
        set => DynamicMetadata.SetThreadSafe(this, value);
    }

    IDictionary<string, object?>? IMetadata.Metadata
    {
        get => Metadata;
        set => Metadata = (IThreadSafeDictionary<string, object?>?) value;
    }
}
