using System;
using System.Runtime.CompilerServices;

namespace Qommon.Collections.Specialized
{
    /// <inheritdoc cref="IBitVector{TData}"/>
    /// <remarks>
    ///     <c>32</c> refers to the size of this vector
    ///     as it uses <see cref="uint"/> for storing bits.
    /// </remarks>
    public struct BitVector32 : IBitVector<uint>, IEquatable<BitVector32>
    {
        /// <summary>
        ///     The amount of bits available in this vector type.
        /// </summary>
        public const int Bits = 32;

        /// <inheritdoc/>
        public uint Data => _data;

        /// <inheritdoc/>
        public bool this[int bit]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] get => IsSet(bit);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] set => Set(bit, value);
        }

        private uint _data;

        public BitVector32(uint data)
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
            _data |= 1u << bit;
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
            _data &= ~(1u << bit);
        }

        /// <inheritdoc/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Flip(int bit)
        {
            _data ^= 1u << bit;
        }

        /// <inheritdoc/>
        public bool Equals(BitVector32 other)
        {
            return _data == other._data;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
            => obj is BitVector32 vector && vector._data == _data;

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return _data.GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
            => $"{nameof(BitVector32)}{{{Convert.ToString((int) _data, 2).PadLeft(32, '0')}}}";

        public static bool operator ==(BitVector32 left, BitVector32 right)
        {
            return left._data == right._data;
        }

        public static bool operator !=(BitVector32 left, BitVector32 right)
        {
            return left._data != right._data;
        }
    }
}
