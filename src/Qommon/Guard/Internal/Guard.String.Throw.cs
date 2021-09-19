using System;
using System.Diagnostics.CodeAnalysis;

namespace Qommon
{
    public static partial class Guard
    {
        private static partial class Throw
        {
            [DoesNotReturn]
            public static void ArgumentExceptionForIsNullOrEmpty(string text, string name)
            {
                throw new ArgumentException($"Parameter {GetNameString(name)} (string) must be null or empty, was {GetValueString(text)}.", name);
            }

            [DoesNotReturn]
            public static void ArgumentExceptionForIsNotNullOrEmpty(string text, string name)
            {
                throw new ArgumentException($"Parameter {GetNameString(name)} (string) must not be null or empty, was {(text is null ? "null" : "empty")}.", name);
            }

            [DoesNotReturn]
            public static void ArgumentExceptionForIsNullOrWhiteSpace(string text, string name)
            {
                throw new ArgumentException($"Parameter {GetNameString(name)} (string) must be null or whitespace, was {GetValueString(text)}.", name);
            }

            [DoesNotReturn]
            public static void ArgumentExceptionForIsNotNullOrWhiteSpace(string text, string name)
            {
                throw new ArgumentException($"Parameter {GetNameString(name)} (string) must not be null or whitespace, was {(text is null ? "null" : "whitespace")}.", name);
            }

            [DoesNotReturn]
            public static void ArgumentExceptionForIsEmpty(string text, string name)
            {
                throw new ArgumentException($"Parameter {GetNameString(name)} (string) must be empty, was {GetValueString(text)}.", name);
            }

            [DoesNotReturn]
            public static void ArgumentExceptionForIsNotEmpty(string name)
            {
                throw new ArgumentException($"Parameter {GetNameString(name)} (string) must not be empty.", name);
            }

            [DoesNotReturn]
            public static void ArgumentExceptionForIsWhiteSpace(string text, string name)
            {
                throw new ArgumentException($"Parameter {GetNameString(name)} (string) must be whitespace, was {GetValueString(text)}.", name);
            }

            [DoesNotReturn]
            public static void ArgumentExceptionForIsNotWhiteSpace(string text, string name)
            {
                throw new ArgumentException($"Parameter {GetNameString(name)} (string) must not be whitespace, was {GetValueString(text)}.", name);
            }

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeEqualTo(string text, int size, string name)
            {
                throw new ArgumentException($"Parameter {GetNameString(name)} (string) must have a size equal to {size}, had a size of {text.Length} and was {GetValueString(text)}.", name);
            }

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeNotEqualTo(string text, int size, string name)
            {
                throw new ArgumentException($"Parameter {GetNameString(name)} (string) must not have a size equal to {size}, was {GetValueString(text)}.", name);
            }

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeGreaterThan(string text, int size, string name)
            {
                throw new ArgumentException($"Parameter {GetNameString(name)} (string) must have a size over {size}, had a size of {text.Length} and was {GetValueString(text)}.", name);
            }

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeGreaterThanOrEqualTo(string text, int size, string name)
            {
                throw new ArgumentException($"Parameter {GetNameString(name)} (string) must have a size of at least {size}, had a size of {text.Length} and was {GetValueString(text)}.", name);
            }

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeLessThan(string text, int size, string name)
            {
                throw new ArgumentException($"Parameter {GetNameString(name)} (string) must have a size less than {size}, had a size of {text.Length} and was {GetValueString(text)}.", name);
            }

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeLessThanOrEqualTo(string text, int size, string name)
            {
                throw new ArgumentException($"Parameter {GetNameString(name)} (string) must have a size less than or equal to {size}, had a size of {text.Length} and was {GetValueString(text)}.", name);
            }

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeEqualTo(string source, string destination, string name)
            {
                throw new ArgumentException($"The source {GetNameString(name)} (string) must have a size equal to {GetValueString(destination.Length)} (the destination), had a size of {GetValueString(source.Length)}.", name);
            }

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeLessThanOrEqualTo(string source, string destination, string name)
            {
                throw new ArgumentException($"The source {GetNameString(name)} (string) must have a size less than or equal to {GetValueString(destination.Length)} (the destination), had a size of {GetValueString(source.Length)}.", name);
            }

            [DoesNotReturn]
            public static void ArgumentOutOfRangeExceptionForIsInRangeFor(int index, string text, string name)
            {
                throw new ArgumentOutOfRangeException(name, index, $"Parameter {GetNameString(name)} (int) must be in the range given by <0> and {GetValueString(text.Length)} to be a valid index for the target string, was {GetValueString(index)}.");
            }

            [DoesNotReturn]
            public static void ArgumentOutOfRangeExceptionForIsNotInRangeFor(int index, string text, string name)
            {
                throw new ArgumentOutOfRangeException(name, index, $"Parameter {GetNameString(name)} (int) must not be in the range given by <0> and {GetValueString(text.Length)} to be an invalid index for the target string, was {GetValueString(index)}.");
            }
        }
    }
}
