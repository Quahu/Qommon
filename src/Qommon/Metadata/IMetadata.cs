using System.Collections.Generic;

namespace Qommon
{
    /// <summary>
    ///     Represents an object that can have extra data attached via a dictionary.
    /// </summary>
    public interface IMetadata
    {
        /// <summary>
        ///     Gets the metadata of this entity, i.e. dynamic data keyed by <see cref="string"/>s.
        /// </summary>
        IDictionary<string, object> Metadata { get; set; }
    }
}
