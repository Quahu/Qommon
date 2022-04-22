using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Qommon;

public static partial class Guard
{
    private static partial class Throw
    {
        [DoesNotReturn]
        public static void ArgumentExceptionForCanRead(Stream stream, string? name)
            => throw new ArgumentException($"Stream {GetValueString(name)} ({stream.GetType().ToTypeString()}) does not support reading.", name);

        [DoesNotReturn]
        public static void ArgumentExceptionForCanWrite(Stream stream, string? name)
            => throw new ArgumentException($"Stream {GetValueString(name)} ({stream.GetType().ToTypeString()}) does not support writing.", name);

        [DoesNotReturn]
        public static void ArgumentExceptionForCanSeek(Stream stream, string? name)
            => throw new ArgumentException($"Stream {GetValueString(name)} ({stream.GetType().ToTypeString()}) does not support seeking.", name);

        [DoesNotReturn]
        public static void ArgumentExceptionForIsAtStartPosition(Stream stream, string? name)
            => throw new ArgumentException($"Stream {GetValueString(name)} ({stream.GetType().ToTypeString()}) must be at position {GetValueString(0)}, was at {GetValueString(stream.Position)}.", name);
    }
}