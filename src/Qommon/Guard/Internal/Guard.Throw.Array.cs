using System;
using System.Diagnostics.CodeAnalysis;

namespace Qommon
{
    public static partial class Guard
    {
        private static partial class Throw
        {
            [DoesNotReturn]
            public static void ArgumentExceptionForIsNotMultiDimensional(string name)
            {
                throw new ArgumentException($"Parameter {GetNameString(name)} must not be a multi-dimensional array.", name);
            }
        }
    }
}
