using System.Runtime.CompilerServices;

namespace Qommon.Buffers;

/// <summary>
///     Represents utilities used with native code.
/// </summary>
public static class NativeUtilities
{
    /// <summary>
    ///     Calculates the amount of bytes needed to contain
    ///     <paramref name="elementCount"/> elements of <paramref name="elementSize"/> size.
    /// </summary>
    /// <param name="elementCount"> The amount of elements. </param>
    /// <param name="elementSize"> The size of an element. </param>
    /// <returns>
    ///     The calculated byte amount.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe nuint GetByteCount(nuint elementCount, nuint elementSize)
    {
        // This is based on the `mi_count_size_overflow` and `mi_mul_overflow` methods from microsoft/mimalloc.
        // Original source is Copyright (c) 2019 Microsoft Corporation, Daan Leijen. Licensed under the MIT license

        // sqrt(nuint.MaxValue)
        var multiplyNoOverflow = (nuint) 1 << (4 * sizeof(nuint));

        return ((elementSize >= multiplyNoOverflow) || (elementCount >= multiplyNoOverflow))
            && (elementSize > 0)
            && ((nuint.MaxValue / elementSize) < elementCount)
                ? nuint.MaxValue
                : (elementCount * elementSize);
    }
}
