using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Qommon
{
    public static partial class Guard
    {
        private static partial class Throw
        {
            [DoesNotReturn]
            public static void ArgumentExceptionForIsEmpty<T>(Span<T> span, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(Span<T>).ToTypeString()}) must be empty, had a size of {GetValueString(span.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeEqualTo<T>(Span<T> span, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(Span<T>).ToTypeString()}) must have a size equal to {size}, had a size of {GetValueString(span.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeNotEqualTo<T>(Span<T> span, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(Span<T>).ToTypeString()}) must have a size not equal to {size}, had a size of {GetValueString(span.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeGreaterThan<T>(Span<T> span, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(Span<T>).ToTypeString()}) must have a size over {size}, had a size of {GetValueString(span.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeGreaterThanOrEqualTo<T>(Span<T> span, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(Span<T>).ToTypeString()}) must have a size of at least {size}, had a size of {GetValueString(span.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeLessThan<T>(Span<T> span, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(Span<T>).ToTypeString()}) must have a size less than {size}, had a size of {GetValueString(span.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeLessThanOrEqualTo<T>(Span<T> span, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(Span<T>).ToTypeString()}) must have a size less than or equal to {size}, had a size of {GetValueString(span.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeEqualTo<T>(Span<T> source, Span<T> destination, string name)
                => throw new ArgumentException($"The source {GetNameString(name)} ({typeof(Span<T>).ToTypeString()}) must have a size equal to {GetValueString(destination.Length)} (the destination), had a size of {GetValueString(source.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeLessThanOrEqualTo<T>(Span<T> source, Span<T> destination, string name)
                => throw new ArgumentException($"The source {GetNameString(name)} ({typeof(Span<T>).ToTypeString()}) must have a size less than or equal to {GetValueString(destination.Length)} (the destination), had a size of {GetValueString(source.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentOutOfRangeExceptionForIsInRangeFor<T>(int index, Span<T> span, string name)
                => throw new ArgumentOutOfRangeException(name, index, $"Parameter {GetNameString(name)} (int) must be in the range given by <0> and {GetValueString(span.Length)} to be a valid index for the target collection ({typeof(Span<T>).ToTypeString()}), was {GetValueString(index)}");

            [DoesNotReturn]
            public static void ArgumentOutOfRangeExceptionForIsNotInRangeFor<T>(int index, Span<T> span, string name)
                => throw new ArgumentOutOfRangeException(name, index, $"Parameter {GetNameString(name)} (int) must not be in the range given by <0> and {GetValueString(span.Length)} to be an invalid index for the target collection ({typeof(Span<T>).ToTypeString()}), was {GetValueString(index)}");

            [DoesNotReturn]
            public static void ArgumentExceptionForIsEmpty<T>(ReadOnlySpan<T> span, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(ReadOnlySpan<T>).ToTypeString()}) must be empty, had a size of {GetValueString(span.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeEqualTo<T>(ReadOnlySpan<T> span, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(ReadOnlySpan<T>).ToTypeString()}) must have a size equal to {size}, had a size of {GetValueString(span.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeNotEqualTo<T>(ReadOnlySpan<T> span, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(ReadOnlySpan<T>).ToTypeString()}) must have a size not equal to {size}, had a size of {GetValueString(span.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeGreaterThan<T>(ReadOnlySpan<T> span, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(ReadOnlySpan<T>).ToTypeString()}) must have a size over {size}, had a size of {GetValueString(span.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeGreaterThanOrEqualTo<T>(ReadOnlySpan<T> span, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(ReadOnlySpan<T>).ToTypeString()}) must have a size of at least {size}, had a size of {GetValueString(span.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeLessThan<T>(ReadOnlySpan<T> span, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(ReadOnlySpan<T>).ToTypeString()}) must have a size less than {size}, had a size of {GetValueString(span.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeLessThanOrEqualTo<T>(ReadOnlySpan<T> span, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(ReadOnlySpan<T>).ToTypeString()}) must have a size less than or equal to {size}, had a size of {GetValueString(span.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeEqualTo<T>(ReadOnlySpan<T> source, Span<T> destination, string name)
                => throw new ArgumentException($"The source {GetNameString(name)} ({typeof(ReadOnlySpan<T>).ToTypeString()}) must have a size equal to {GetValueString(destination.Length)} (the destination), had a size of {GetValueString(source.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeLessThanOrEqualTo<T>(ReadOnlySpan<T> source, Span<T> destination, string name)
                => throw new ArgumentException($"The source {GetNameString(name)} ({typeof(ReadOnlySpan<T>).ToTypeString()}) must have a size less than or equal to {GetValueString(destination.Length)} (the destination), had a size of {GetValueString(source.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentOutOfRangeExceptionForIsInRangeFor<T>(int index, ReadOnlySpan<T> span, string name)
                => throw new ArgumentOutOfRangeException(name, index, $"Parameter {GetNameString(name)} (int) must be in the range given by <0> and {GetValueString(span.Length)} to be a valid index for the target collection ({typeof(ReadOnlySpan<T>).ToTypeString()}), was {GetValueString(index)}");

            [DoesNotReturn]
            public static void ArgumentOutOfRangeExceptionForIsNotInRangeFor<T>(int index, ReadOnlySpan<T> span, string name)
                => throw new ArgumentOutOfRangeException(name, index, $"Parameter {GetNameString(name)} (int) must not be in the range given by <0> and {GetValueString(span.Length)} to be an invalid index for the target collection ({typeof(ReadOnlySpan<T>).ToTypeString()}), was {GetValueString(index)}");

            [DoesNotReturn]
            public static void ArgumentExceptionForIsEmpty<T>(Memory<T> memory, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(Memory<T>).ToTypeString()}) must be empty, had a size of {GetValueString(memory.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeEqualTo<T>(Memory<T> memory, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(Memory<T>).ToTypeString()}) must have a size equal to {size}, had a size of {GetValueString(memory.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeNotEqualTo<T>(Memory<T> memory, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(Memory<T>).ToTypeString()}) must have a size not equal to {size}, had a size of {GetValueString(memory.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeGreaterThan<T>(Memory<T> memory, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(Memory<T>).ToTypeString()}) must have a size over {size}, had a size of {GetValueString(memory.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeGreaterThanOrEqualTo<T>(Memory<T> memory, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(Memory<T>).ToTypeString()}) must have a size of at least {size}, had a size of {GetValueString(memory.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeLessThan<T>(Memory<T> memory, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(Memory<T>).ToTypeString()}) must have a size less than {size}, had a size of {GetValueString(memory.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeLessThanOrEqualTo<T>(Memory<T> memory, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(Memory<T>).ToTypeString()}) must have a size less than or equal to {size}, had a size of {GetValueString(memory.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeEqualTo<T>(Memory<T> source, Memory<T> destination, string name)
                => throw new ArgumentException($"The source {GetNameString(name)} ({typeof(Memory<T>).ToTypeString()}) must have a size equal to {GetValueString(destination.Length)} (the destination), had a size of {GetValueString(source.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeLessThanOrEqualTo<T>(Memory<T> source, Memory<T> destination, string name)
                => throw new ArgumentException($"The source {GetNameString(name)} ({typeof(Memory<T>).ToTypeString()}) must have a size less than or equal to {GetValueString(destination.Length)} (the destination), had a size of {GetValueString(source.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentOutOfRangeExceptionForIsInRangeFor<T>(int index, Memory<T> memory, string name)
                => throw new ArgumentOutOfRangeException(name, index, $"Parameter {GetNameString(name)} (int) must be in the range given by <0> and {GetValueString(memory.Length)} to be a valid index for the target collection ({typeof(Memory<T>).ToTypeString()}), was {GetValueString(index)}");

            [DoesNotReturn]
            public static void ArgumentOutOfRangeExceptionForIsNotInRangeFor<T>(int index, Memory<T> memory, string name)
                => throw new ArgumentOutOfRangeException(name, index, $"Parameter {GetNameString(name)} (int) must not be in the range given by <0> and {GetValueString(memory.Length)} to be an invalid index for the target collection ({typeof(Memory<T>).ToTypeString()}), was {GetValueString(index)}");

            [DoesNotReturn]
            public static void ArgumentExceptionForIsEmpty<T>(ReadOnlyMemory<T> memory, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(ReadOnlyMemory<T>).ToTypeString()}) must be empty, had a size of {GetValueString(memory.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeEqualTo<T>(ReadOnlyMemory<T> memory, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(ReadOnlyMemory<T>).ToTypeString()}) must have a size equal to {size}, had a size of {GetValueString(memory.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeNotEqualTo<T>(ReadOnlyMemory<T> memory, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(ReadOnlyMemory<T>).ToTypeString()}) must have a size not equal to {size}, had a size of {GetValueString(memory.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeGreaterThan<T>(ReadOnlyMemory<T> memory, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(ReadOnlyMemory<T>).ToTypeString()}) must have a size over {size}, had a size of {GetValueString(memory.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeGreaterThanOrEqualTo<T>(ReadOnlyMemory<T> memory, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(ReadOnlyMemory<T>).ToTypeString()}) must have a size of at least {size}, had a size of {GetValueString(memory.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeLessThan<T>(ReadOnlyMemory<T> memory, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(ReadOnlyMemory<T>).ToTypeString()}) must have a size less than {size}, had a size of {GetValueString(memory.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeLessThanOrEqualTo<T>(ReadOnlyMemory<T> memory, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(ReadOnlyMemory<T>).ToTypeString()}) must have a size less than or equal to {size}, had a size of {GetValueString(memory.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeEqualTo<T>(ReadOnlyMemory<T> source, Memory<T> destination, string name)
                => throw new ArgumentException($"The source {GetNameString(name)} ({typeof(ReadOnlyMemory<T>).ToTypeString()}) must have a size equal to {GetValueString(destination.Length)} (the destination), had a size of {GetValueString(source.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeLessThanOrEqualTo<T>(ReadOnlyMemory<T> source, Memory<T> destination, string name)
                => throw new ArgumentException($"The source {GetNameString(name)} ({typeof(ReadOnlyMemory<T>).ToTypeString()}) must have a size less than or equal to {GetValueString(destination.Length)} (the destination), had a size of {GetValueString(source.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentOutOfRangeExceptionForIsInRangeFor<T>(int index, ReadOnlyMemory<T> memory, string name)
                => throw new ArgumentOutOfRangeException(name, index, $"Parameter {GetNameString(name)} (int) must be in the range given by <0> and {GetValueString(memory.Length)} to be a valid index for the target collection ({typeof(ReadOnlyMemory<T>).ToTypeString()}), was {GetValueString(index)}");

            [DoesNotReturn]
            public static void ArgumentOutOfRangeExceptionForIsNotInRangeFor<T>(int index, ReadOnlyMemory<T> memory, string name)
                => throw new ArgumentOutOfRangeException(name, index, $"Parameter {GetNameString(name)} (int) must not be in the range given by <0> and {GetValueString(memory.Length)} to be an invalid index for the target collection ({typeof(ReadOnlyMemory<T>).ToTypeString()}), was {GetValueString(index)}");

            [DoesNotReturn]
            public static void ArgumentExceptionForIsEmpty<T>(T[] array, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(T[]).ToTypeString()}) must be empty, had a size of {GetValueString(array.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeEqualTo<T>(T[] array, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(T[]).ToTypeString()}) must have a size equal to {size}, had a size of {GetValueString(array.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeNotEqualTo<T>(T[] array, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(T[]).ToTypeString()}) must have a size not equal to {size}, had a size of {GetValueString(array.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeGreaterThan<T>(T[] array, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(T[]).ToTypeString()}) must have a size over {size}, had a size of {GetValueString(array.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeGreaterThanOrEqualTo<T>(T[] array, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(T[]).ToTypeString()}) must have a size of at least {size}, had a size of {GetValueString(array.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeLessThan<T>(T[] array, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(T[]).ToTypeString()}) must have a size less than {size}, had a size of {GetValueString(array.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeLessThanOrEqualTo<T>(T[] array, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(T[]).ToTypeString()}) must have a size less than or equal to {size}, had a size of {GetValueString(array.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeEqualTo<T>(T[] source, T[] destination, string name)
                => throw new ArgumentException($"The source {GetNameString(name)} ({typeof(T[]).ToTypeString()}) must have a size equal to {GetValueString(destination.Length)} (the destination), had a size of {GetValueString(source.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeLessThanOrEqualTo<T>(T[] source, T[] destination, string name)
                => throw new ArgumentException($"The source {GetNameString(name)} ({typeof(T[]).ToTypeString()}) must have a size less than or equal to {GetValueString(destination.Length)} (the destination), had a size of {GetValueString(source.Length)}.", name);

            [DoesNotReturn]
            public static void ArgumentOutOfRangeExceptionForIsInRangeFor<T>(int index, T[] array, string name)
                => throw new ArgumentOutOfRangeException(name, index, $"Parameter {GetNameString(name)} (int) must be in the range given by <0> and {GetValueString(array.Length)} to be a valid index for the target collection ({typeof(T[]).ToTypeString()}), was {GetValueString(index)}");

            [DoesNotReturn]
            public static void ArgumentOutOfRangeExceptionForIsNotInRangeFor<T>(int index, T[] array, string name)
                => throw new ArgumentOutOfRangeException(name, index, $"Parameter {GetNameString(name)} (int) must not be in the range given by <0> and {GetValueString(array.Length)} to be an invalid index for the target collection ({typeof(T[]).ToTypeString()}), was {GetValueString(index)}");

            [DoesNotReturn]
            public static void ArgumentExceptionForIsEmpty<T>(List<T> list, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(List<T>).ToTypeString()}) must be empty, had a size of {GetValueString(list.Count)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeEqualTo<T>(List<T> list, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(List<T>).ToTypeString()}) must have a size equal to {size}, had a size of {GetValueString(list.Count)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeNotEqualTo<T>(List<T> list, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(List<T>).ToTypeString()}) must have a size not equal to {size}, had a size of {GetValueString(list.Count)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeGreaterThan<T>(List<T> list, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(List<T>).ToTypeString()}) must have a size over {size}, had a size of {GetValueString(list.Count)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeGreaterThanOrEqualTo<T>(List<T> list, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(List<T>).ToTypeString()}) must have a size of at least {size}, had a size of {GetValueString(list.Count)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeLessThan<T>(List<T> list, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(List<T>).ToTypeString()}) must have a size less than {size}, had a size of {GetValueString(list.Count)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeLessThanOrEqualTo<T>(List<T> list, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(List<T>).ToTypeString()}) must have a size less than or equal to {size}, had a size of {GetValueString(list.Count)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeEqualTo<T>(List<T> source, List<T> destination, string name)
                => throw new ArgumentException($"The source {GetNameString(name)} ({typeof(List<T>).ToTypeString()}) must have a size equal to {GetValueString(destination.Count)} (the destination), had a size of {GetValueString(source.Count)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeLessThanOrEqualTo<T>(List<T> source, List<T> destination, string name)
                => throw new ArgumentException($"The source {GetNameString(name)} ({typeof(List<T>).ToTypeString()}) must have a size less than or equal to {GetValueString(destination.Count)} (the destination), had a size of {GetValueString(source.Count)}.", name);

            [DoesNotReturn]
            public static void ArgumentOutOfRangeExceptionForIsInRangeFor<T>(int index, List<T> list, string name)
                => throw new ArgumentOutOfRangeException(name, index, $"Parameter {GetNameString(name)} (int) must be in the range given by <0> and {GetValueString(list.Count)} to be a valid index for the target collection ({typeof(List<T>).ToTypeString()}), was {GetValueString(index)}");

            [DoesNotReturn]
            public static void ArgumentOutOfRangeExceptionForIsNotInRangeFor<T>(int index, List<T> list, string name)
                => throw new ArgumentOutOfRangeException(name, index, $"Parameter {GetNameString(name)} (int) must not be in the range given by <0> and {GetValueString(list.Count)} to be an invalid index for the target collection ({typeof(List<T>).ToTypeString()}), was {GetValueString(index)}");

            [DoesNotReturn]
            public static void ArgumentExceptionForIsEmpty<T>(ICollection<T> collection, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(ICollection<T>).ToTypeString()}) must be empty, had a size of {GetValueString(collection.Count)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeEqualTo<T>(ICollection<T> collection, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(ICollection<T>).ToTypeString()}) must have a size equal to {size}, had a size of {GetValueString(collection.Count)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeNotEqualTo<T>(ICollection<T> collection, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(ICollection<T>).ToTypeString()}) must have a size not equal to {size}, had a size of {GetValueString(collection.Count)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeGreaterThan<T>(ICollection<T> collection, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(ICollection<T>).ToTypeString()}) must have a size over {size}, had a size of {GetValueString(collection.Count)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeGreaterThanOrEqualTo<T>(ICollection<T> collection, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(ICollection<T>).ToTypeString()}) must have a size of at least {size}, had a size of {GetValueString(collection.Count)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeLessThan<T>(ICollection<T> collection, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(ICollection<T>).ToTypeString()}) must have a size less than {size}, had a size of {GetValueString(collection.Count)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeLessThanOrEqualTo<T>(ICollection<T> collection, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(ICollection<T>).ToTypeString()}) must have a size less than or equal to {size}, had a size of {GetValueString(collection.Count)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeEqualTo<T>(ICollection<T> source, ICollection<T> destination, string name)
                => throw new ArgumentException($"The source {GetNameString(name)} ({typeof(ICollection<T>).ToTypeString()}) must have a size equal to {GetValueString(destination.Count)} (the destination), had a size of {GetValueString(source.Count)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeLessThanOrEqualTo<T>(ICollection<T> source, ICollection<T> destination, string name)
                => throw new ArgumentException($"The source {GetNameString(name)} ({typeof(ICollection<T>).ToTypeString()}) must have a size less than or equal to {GetValueString(destination.Count)} (the destination), had a size of {GetValueString(source.Count)}.", name);

            [DoesNotReturn]
            public static void ArgumentOutOfRangeExceptionForIsInRangeFor<T>(int index, ICollection<T> collection, string name)
                => throw new ArgumentOutOfRangeException(name, index, $"Parameter {GetNameString(name)} (int) must be in the range given by <0> and {GetValueString(collection.Count)} to be a valid index for the target collection ({typeof(ICollection<T>).ToTypeString()}), was {GetValueString(index)}");

            [DoesNotReturn]
            public static void ArgumentOutOfRangeExceptionForIsNotInRangeFor<T>(int index, ICollection<T> collection, string name)
                => throw new ArgumentOutOfRangeException(name, index, $"Parameter {GetNameString(name)} (int) must not be in the range given by <0> and {GetValueString(collection.Count)} to be an invalid index for the target collection ({typeof(ICollection<T>).ToTypeString()}), was {GetValueString(index)}");

            [DoesNotReturn]
            public static void ArgumentExceptionForIsEmpty<T>(IReadOnlyCollection<T> collection, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(IReadOnlyCollection<T>).ToTypeString()}) must be empty, had a size of {GetValueString(collection.Count)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeEqualTo<T>(IReadOnlyCollection<T> collection, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(IReadOnlyCollection<T>).ToTypeString()}) must have a size equal to {size}, had a size of {GetValueString(collection.Count)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeNotEqualTo<T>(IReadOnlyCollection<T> collection, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(IReadOnlyCollection<T>).ToTypeString()}) must have a size not equal to {size}, had a size of {GetValueString(collection.Count)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeGreaterThan<T>(IReadOnlyCollection<T> collection, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(IReadOnlyCollection<T>).ToTypeString()}) must have a size over {size}, had a size of {GetValueString(collection.Count)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeGreaterThanOrEqualTo<T>(IReadOnlyCollection<T> collection, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(IReadOnlyCollection<T>).ToTypeString()}) must have a size of at least {size}, had a size of {GetValueString(collection.Count)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeLessThan<T>(IReadOnlyCollection<T> collection, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(IReadOnlyCollection<T>).ToTypeString()}) must have a size less than {size}, had a size of {GetValueString(collection.Count)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeLessThanOrEqualTo<T>(IReadOnlyCollection<T> collection, int size, string name)
                => throw new ArgumentException($"Parameter {GetNameString(name)} ({typeof(IReadOnlyCollection<T>).ToTypeString()}) must have a size less than or equal to {size}, had a size of {GetValueString(collection.Count)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeEqualTo<T>(IReadOnlyCollection<T> source, ICollection<T> destination, string name)
                => throw new ArgumentException($"The source {GetNameString(name)} ({typeof(IReadOnlyCollection<T>).ToTypeString()}) must have a size equal to {GetValueString(destination.Count)} (the destination), had a size of {GetValueString(source.Count)}.", name);

            [DoesNotReturn]
            public static void ArgumentExceptionForHasSizeLessThanOrEqualTo<T>(IReadOnlyCollection<T> source, ICollection<T> destination, string name)
                => throw new ArgumentException($"The source {GetNameString(name)} ({typeof(IReadOnlyCollection<T>).ToTypeString()}) must have a size less than or equal to {GetValueString(destination.Count)} (the destination), had a size of {GetValueString(source.Count)}.", name);

            [DoesNotReturn]
            public static void ArgumentOutOfRangeExceptionForIsInRangeFor<T>(int index, IReadOnlyCollection<T> collection, string name)
                => throw new ArgumentOutOfRangeException(name, index, $"Parameter {GetNameString(name)} (int) must be in the range given by <0> and {GetValueString(collection.Count)} to be a valid index for the target collection ({typeof(IReadOnlyCollection<T>).ToTypeString()}), was {GetValueString(index)}");

            [DoesNotReturn]
            public static void ArgumentOutOfRangeExceptionForIsNotInRangeFor<T>(int index, IReadOnlyCollection<T> collection, string name)
                => throw new ArgumentOutOfRangeException(name, index, $"Parameter {GetNameString(name)} (int) must not be in the range given by <0> and {GetValueString(collection.Count)} to be an invalid index for the target collection ({typeof(IReadOnlyCollection<T>).ToTypeString()}), was {GetValueString(index)}");
        }
    }
}
