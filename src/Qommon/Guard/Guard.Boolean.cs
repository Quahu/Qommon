using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Qommon;

public static partial class Guard
{
    /// <summary>
    ///     Asserts that the input value must be <see langword="true"/>.
    /// </summary>
    /// <param name="value"> The value to test. </param>
    /// <param name="name"> The name of the input parameter being tested. </param>
    /// <param name="message"> A message to display if <paramref name="value"/> is <see langword="false"/>. </param>
    /// <exception cref="ArgumentException">
    ///     Thrown if <paramref name="value"/> is <see langword="false"/>.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void IsTrue([DoesNotReturnIf(false)] bool value, [CallerArgumentExpression("value")] string? name = null, string? message = null)
    {
        if (value)
            return;

        Throw.ArgumentExceptionForIsTrue(name, message);
    }

    /// <summary>
    ///     Asserts that the input value must be <see langword="false"/>.
    /// </summary>
    /// <param name="value"> The value to test. </param>
    /// <param name="name"> The name of the input parameter being tested. </param>
    /// <param name="message"> A message to display if <paramref name="value"/> is <see langword="true"/>. </param>
    /// <exception cref="ArgumentException"> Thrown if <paramref name="value"/> is <see langword="true"/>. </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void IsFalse([DoesNotReturnIf(true)] bool value, [CallerArgumentExpression("value")] string? name = null, string? message = null)
    {
        if (!value)
            return;

        Throw.ArgumentExceptionForIsFalse(name, message);
    }
}