namespace Qommon.Collections.Specialized;

/// <summary>
///     Represents a bit vector, i.e. a binary view over an integral data type.
///     This easily allows to inspect and manipulate individuals bits of said type.
/// </summary>
/// <typeparam name="TData"> The type of the underlying data type. </typeparam>
public interface IBitVector<TData>
{
    /// <summary>
    ///     Gets the underlying data.
    /// </summary>
    TData Data { get; }

    /// <summary>
    ///     Gets or sets the value of a bit in this vector.
    /// </summary>
    /// <param name="bit"> The bit to get or set the value of. </param>
    bool this[int bit] { get; set; }

    /// <summary>
    ///     Gets the value of a bit in this vector.
    /// </summary>
    /// <param name="bit"> The bit to get the value of. </param>
    /// <returns>
    ///     <see langword="true"/> if the bit is set, <see langword="false"/> otherwise.
    /// </returns>
    bool IsSet(int bit);

    /// <summary>
    ///     Sets the value of a bit in this vector to <see langword="true"/>.
    /// </summary>
    /// <param name="bit"> The bit to set the value of. </param>
    void Set(int bit);

    /// <summary>
    ///     Sets the value of a bit in this vector to the specified value.
    /// </summary>
    /// <param name="bit"> The bit to set the value of. </param>
    /// <param name="value"> The value to set the bit to. </param>
    void Set(int bit, bool value);

    /// <summary>
    ///     Resets the value of a bit in this vector to <see langword="false"/>.
    /// </summary>
    /// <param name="bit"> The bit to reset the value of. </param>
    void Reset(int bit);

    /// <summary>
    ///     Flips the value of a bit in this vector to <see langword="false"/>.
    /// </summary>
    /// <param name="bit"> The bit to reset the value of. </param>
    void Flip(int bit);
}