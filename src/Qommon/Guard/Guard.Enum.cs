using System;
using System.Runtime.CompilerServices;

namespace Qommon;

public static partial class Guard
{
    /// <summary>
    ///     Asserts that the input value is defined within its <see langword="enum"/> type.
    /// </summary>
    /// <param name="value"> The input <see langword="enum"/> to test. </param>
    /// <param name="name"> The name of the input parameter being tested. </param>
    /// <exception cref="ArgumentException">
    ///     Thrown if <paramref name="value"/> is not defined within the <see langword="enum"/>.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void IsDefined<TEnum>(TEnum value, [CallerArgumentExpression("value")] string? name = null)
        where TEnum : struct, Enum
    {
        if (Enum.IsDefined(value))
            return;

        Throw.ArgumentOutOfRangeExceptionForIsDefined(value, name);
    }
}
