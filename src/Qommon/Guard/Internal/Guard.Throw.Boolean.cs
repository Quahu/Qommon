using System;
using System.Diagnostics.CodeAnalysis;

namespace Qommon
{
    public static partial class Guard
    {
        private static partial class Throw
        {
            [DoesNotReturn]
            public static void ArgumentExceptionForIsTrue(string name, string message)
            {
                if (message == null)
                    throw new ArgumentException($"Parameter {GetNameString(name)} must be true, was false.", name);

                throw new ArgumentException($"Parameter {GetNameString(name)} must be true, was false: {GetValueString(message)}.", name);
            }

            [DoesNotReturn]
            public static void ArgumentExceptionForIsFalse(string name, string message)
            {
                if (message == null)
                    throw new ArgumentException($"Parameter {GetNameString(name)} must be false, was true.", name);

                throw new ArgumentException($"Parameter {GetNameString(name)} must be false, was true: {GetValueString(message)}.", name);
            }
        }
    }
}
