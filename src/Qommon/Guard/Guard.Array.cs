using System;
using System.Runtime.CompilerServices;

namespace Qommon;

public static partial class Guard
{
    /// <summary>
    ///     Asserts that the input array must not be multi-dimensional.
    /// </summary>
    /// <param name="array"> The value to test. </param>
    /// <param name="name"> The name of the input parameter being tested. </param>
    /// <exception cref="ArgumentException">
    ///     Thrown if <paramref name="array"/> is a multi-dimensional array.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void IsNotMultiDimensional(Array array, [CallerArgumentExpression("array")] string? name = null)
    {
        if (array.Rank == 1)
            return;

        Throw.ArgumentExceptionForIsNotMultiDimensional(name);
    }
}