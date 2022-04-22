using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace Qommon;

public static partial class Guard
{
    /// <summary>
    ///     Asserts that the input <see cref="Stream"/> instance must support reading.
    /// </summary>
    /// <param name="stream"> The input <see cref="Stream"/> instance to test. </param>
    /// <param name="name"> The name of the input parameter being tested. </param>
    /// <exception cref="ArgumentException">
    ///      Thrown if <paramref name="stream"/> doesn't support reading.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void CanRead(Stream stream, [CallerArgumentExpression("stream")] string? name = null)
    {
        if (stream.CanRead)
            return;

        Throw.ArgumentExceptionForCanRead(stream, name);
    }

    /// <summary>
    ///     Asserts that the input <see cref="Stream"/> instance must support writing.
    /// </summary>
    /// <param name="stream"> The input <see cref="Stream"/> instance to test. </param>
    /// <param name="name"> The name of the input parameter being tested. </param>
    /// <exception cref="ArgumentException">
    ///      Thrown if <paramref name="stream"/> doesn't support writing.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void CanWrite(Stream stream, [CallerArgumentExpression("stream")] string? name = null)
    {
        if (stream.CanWrite)
            return;

        Throw.ArgumentExceptionForCanWrite(stream, name);
    }

    /// <summary>
    ///     Asserts that the input <see cref="Stream"/> instance must support seeking.
    /// </summary>
    /// <param name="stream"> The input <see cref="Stream"/> instance to test. </param>
    /// <param name="name"> The name of the input parameter being tested. </param>
    /// <exception cref="ArgumentException">
    ///      Thrown if <paramref name="stream"/> doesn't support seeking.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void CanSeek(Stream stream, [CallerArgumentExpression("stream")] string? name = null)
    {
        if (stream.CanSeek)
            return;

        Throw.ArgumentExceptionForCanSeek(stream, name);
    }

    /// <summary>
    ///     Asserts that the input <see cref="Stream"/> instance must be at the starting position.
    /// </summary>
    /// <param name="stream"> The input <see cref="Stream"/> instance to test. </param>
    /// <param name="name"> The name of the input parameter being tested. </param>
    /// <exception cref="ArgumentException">
    ///      Thrown if <paramref name="stream"/> is not at the starting position.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void IsAtStartPosition(Stream stream, [CallerArgumentExpression("stream")] string? name = null)
    {
        if (stream.Position == 0)
            return;

        Throw.ArgumentExceptionForIsAtStartPosition(stream, name);
    }
}