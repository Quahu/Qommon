using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Qommon.Collections.Specialized;

/// <inheritdoc cref="IBitVector{TData}"/>
/// <remarks>
///     <c>A</c> refers to the arbitrary size of this vector
///     as it uses <see cref="BigInteger"/> for storing bits.
/// </remarks>
public struct BitVectorA : IBitVector<BigInteger>, IEquatable<BitVectorA>
{
    /// <inheritdoc/>
    public BigInteger Data => _data;

    /// <inheritdoc/>
    public bool this[int bit]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)] get => IsSet(bit);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Set(bit, value);
    }

    private BigInteger _data;

    public BitVectorA(BigInteger data)
    {
        _data = data;
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IsSet(int bit)
    {
        return (_data & (BigInteger.One << bit)) != 0;
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(int bit)
    {
        _data |= BigInteger.One << bit;
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
        _data &= ~(BigInteger.One << bit);
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Flip(int bit)
    {
        _data ^= BigInteger.One << bit;
    }

    /// <inheritdoc/>
    public bool Equals(BitVectorA other)
    {
        return _data == other._data;
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is BitVectorA vector && vector._data == _data;

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return _data.GetHashCode();
    }

    /// <inheritdoc/>
    public override string ToString()
        => $"{nameof(BitVectorA)}{{{_data.GetBitLength()} bits}}";

    public static bool operator ==(BitVectorA left, BitVectorA right)
    {
        return left._data == right._data;
    }

    public static bool operator !=(BitVectorA left, BitVectorA right)
    {
        return left._data != right._data;
    }
}
