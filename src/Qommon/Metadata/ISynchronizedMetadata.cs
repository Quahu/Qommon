using System.Collections.Generic;
using Qommon.Collections.Synchronized;
using Qommon.Metadata.Dynamic;

namespace Qommon.Metadata
{
    /// <summary>
    ///     Represents a type that can have extra data attached to it via a synchronized dictionary.
    /// </summary>
    /// <remarks>
    ///     This interface has a default implementation for the <see cref="Metadata"/>
    ///     property using <see cref="DynamicMetadata"/>.
    /// </remarks>
    public interface ISynchronizedMetadata : IMetadata
    {
        /// <inheritdoc cref="IMetadata.Metadata"/>
        new ISynchronizedDictionary<string, object> Metadata
        {
            get => DynamicMetadata.GetOrCreateSynchronized(this).Metadata;
            set => DynamicMetadata.SetSynchronized(this, value);
        }

        IDictionary<string, object> IMetadata.Metadata
        {
            get => Metadata;
            set => Metadata = (ISynchronizedDictionary<string, object>) value;
        }
    }
}
