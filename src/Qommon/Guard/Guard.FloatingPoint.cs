using System;
using System.Runtime.CompilerServices;

namespace Qommon;

public static partial class Guard
{
    /// <summary>
    ///     Asserts that the input value must be a number.
    /// </summary>
    /// <param name="value"> The input <see cref="double"/> to test. </param>
    /// <param name="name"> The name of the input parameter being tested. </param>
    /// <exception cref="NotFiniteNumberException">
    ///     Thrown if <paramref name="value"/> is not finite (zero, subnormal or normal).
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void IsFinite(double value, [CallerArgumentExpression("value")] string? name = null)
    {
        if (double.IsFinite(value))
            return;

        Throw.ArgumentExceptionForIsFinite(value, name);
    }
}