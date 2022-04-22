using System;
using System.Runtime.CompilerServices;

namespace Qommon.Collections.Specialized;

/// <inheritdoc cref="IBitVector{TData}"/>
/// <remarks>
///     <c>64</c> refers to the size of this vector
///     as it uses <see cref="ulong"/> for storing bits.
/// </remarks>
public struct BitVector64 : IBitVector<ulong>, IEquatable<BitVector64>
{
    /// <summary>
    ///     The amount of bits available in this vector type.
    /// </summary>
    public const int Bits = 64;

    /// <inheritdoc/>
    public ulong Data => _data;

    /// <inheritdoc/>
    public bool this[int bit]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)] get => IsSet(bit);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Set(bit, value);
    }

    private ulong _data;

    public BitVector64(ulong data)
    {
        _data = data;
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IsSet(int bit)
    {
        return (_data & (1ul << bit)) != 0;
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(int bit)
    {
        _data |= 1ul << bit;
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(int bit, bool value)
    {
        if (value)
            Set(bit);
        else
            Reset(bit);
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Reset(int bit)
    {
        _data &= ~(1ul << bit);
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Flip(int bit)
    {
        _data ^= 1ul << bit;
    }

    /// <inheritdoc/>
    public bool Equals(BitVector64 other)
    {
        return _data == other._data;
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is BitVector64 vector && vector._data == _data;

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return _data.GetHashCode();
    }

    /// <inheritdoc/>
    public override string ToString()
        => $"{nameof(BitVector64)}{{{Convert.ToString((long) _data, 2).PadLeft(64, '0')}}}";

    public static bool operator ==(BitVector64 left, BitVector64 right)
    {
        return left._data == right._data;
    }

    public static bool operator !=(BitVector64 left, BitVector64 right)
    {
        return left._data != right._data;
    }
}