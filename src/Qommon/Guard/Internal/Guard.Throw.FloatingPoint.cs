using System;
using System.Diagnostics.CodeAnalysis;

namespace Qommon
{
    public static partial class Guard
    {
        private static partial class Throw
        {
            [DoesNotReturn]
            public static void ArgumentExceptionForIsFinite(double value, string name)
            {
                throw new ArgumentException($"Parameter {GetNameString(name)} must be finite, was {GetValueString(value)}.", name);
            }
        }
    }
}
