using System.Collections.Generic;
using Qommon.Metadata.Dynamic;

namespace Qommon.Metadata
{
    /// <summary>
    ///     Represents a type that can have extra data attached to it via a dictionary.
    /// </summary>
    /// <remarks>
    ///     This interface has a default implementation for the <see cref="Metadata"/>
    ///     property using <see cref="DynamicMetadata"/>.
    /// </remarks>
    public interface IMetadata
    {
        /// <summary>
        ///     Gets the metadata of this entity, i.e. dynamic data keyed by <see cref="string"/>s.
        /// </summary>
        IDictionary<string, object> Metadata
        {
            get => DynamicMetadata.GetOrCreate(this).Metadata;
            set => DynamicMetadata.Set(this, value);
        }
    }
}
