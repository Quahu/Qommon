using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Qommon
{
    /// <summary>
    ///     Represents <see cref="Type"/> extensions.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class TypeExtensions
    {
        private static readonly Dictionary<Type, string> BuiltInTypes = new()
        {
            [typeof(bool)] = "bool",
            [typeof(byte)] = "byte",
            [typeof(sbyte)] = "sbyte",
            [typeof(short)] = "short",
            [typeof(ushort)] = "ushort",
            [typeof(char)] = "char",
            [typeof(int)] = "int",
            [typeof(uint)] = "uint",
            [typeof(float)] = "float",
            [typeof(long)] = "long",
            [typeof(ulong)] = "ulong",
            [typeof(double)] = "double",
            [typeof(decimal)] = "decimal",
            [typeof(object)] = "object",
            [typeof(string)] = "string",
            [typeof(void)] = "void"
        };
        private static readonly ConditionalWeakTable<Type, string> DisplayNames = new();

        /// <summary>
        ///     Returns a human-readable representation of a type.
        /// </summary>
        /// <param name="type"> The type to get the string for. </param>
        /// <returns>
        ///     The string representation of <paramref name="type"/>.
        /// </returns>
        [Pure]
        public static string ToTypeString(this Type type)
        {
            static string FormatDisplayString(Type type, int genericTypeOffset, ReadOnlySpan<Type> typeArguments)
            {
                if (BuiltInTypes.TryGetValue(type, out var typeName))
                    return typeName!;

                if (type.IsArray)
                {
                    var elementType = type.GetElementType()!;
                    var rank = type.GetArrayRank();

                    return $"{FormatDisplayString(elementType, 0, elementType.GetGenericArguments())}[{new string(',', rank - 1)}]";
                }

                if (type.IsGenericType)
                {
                    var genericTypeDefinition = type.GetGenericTypeDefinition();
                    if (genericTypeDefinition == typeof(Nullable<>))
                    {
                        var nullableArguments = type.GetGenericArguments();
                        return $"{FormatDisplayString(nullableArguments[0], 0, nullableArguments)}?";
                    }

                    if (genericTypeDefinition == typeof(ValueTuple<>) ||
                        genericTypeDefinition == typeof(ValueTuple<,>) ||
                        genericTypeDefinition == typeof(ValueTuple<,,>) ||
                        genericTypeDefinition == typeof(ValueTuple<,,,>) ||
                        genericTypeDefinition == typeof(ValueTuple<,,,,>) ||
                        genericTypeDefinition == typeof(ValueTuple<,,,,,>) ||
                        genericTypeDefinition == typeof(ValueTuple<,,,,,,>) ||
                        genericTypeDefinition == typeof(ValueTuple<,,,,,,,>))
                    {
                        var formattedTypes = type.GetGenericArguments().Select(type => FormatDisplayString(type, 0, type.GetGenericArguments()));
                        return $"({string.Join(", ", formattedTypes)})";
                    }
                }

                string displayName;
                if (type.Name.Contains('`'))
                {
                    var tokens = type.Name.Split('`');
                    var genericArgumentsCount = int.Parse(tokens[1]);
                    var typeArgumentsOffset = typeArguments.Length - genericTypeOffset - genericArgumentsCount;
                    var currentTypeArguments = typeArguments.Slice(typeArgumentsOffset, genericArgumentsCount).ToArray();
                    var formattedTypes = currentTypeArguments.Select(type => FormatDisplayString(type, 0, type.GetGenericArguments()));

                    displayName = $"{tokens[0]}<{string.Join(", ", formattedTypes)}>";
                    genericTypeOffset += genericArgumentsCount;
                }
                else
                {
                    displayName = type.Name;
                }

                if (!type.IsNested)
                    return $"{type.Namespace}.{displayName}";

                var openDeclaringType = type.DeclaringType!;
                var rootGenericArguments = typeArguments[..^genericTypeOffset].ToArray();
                if (rootGenericArguments.Length == 0)
                    return $"{FormatDisplayString(openDeclaringType, genericTypeOffset, typeArguments)}.{displayName}";

                var closedDeclaringType = openDeclaringType.GetGenericTypeDefinition().MakeGenericType(rootGenericArguments);
                return $"{FormatDisplayString(closedDeclaringType, genericTypeOffset, typeArguments)}.{displayName}";
            }

            return DisplayNames.GetValue(type, type =>
            {
                if (type.IsByRef)
                {
                    type = type.GetElementType();
                    return $"{FormatDisplayString(type, 0, type.GetGenericArguments())}&";
                }

                if (!type.IsPointer)
                    return FormatDisplayString(type, 0, type.GetGenericArguments());

                var depth = 0;
                while (type.IsPointer)
                {
                    depth++;
                    type = type.GetElementType();
                }

                return $"{FormatDisplayString(type, 0, type.GetGenericArguments())}{new string('*', depth)}";
            });
        }
    }
}
