﻿using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Qommon;

/// <summary>
///     Defines extension methods for <see cref="Optional{T}"/>.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public static class OptionalExtensions
{
    public static T? GetValueOrNullable<T>(this Optional<T> optional)
        where T : struct
        => optional.HasValue ? optional.Value : new T?();

    public static T? GetValueOrDefault<T>(this Optional<T> optional)
        => optional.HasValue ? optional.Value : default;

    public static T GetValueOrDefault<T>(this Optional<T> optional, T value)
        => optional.HasValue ? optional.Value : value;

    public static T GetValueOrDefault<T>(this Optional<T> optional, Func<T> factory)
        => optional.HasValue ? optional.Value : (factory ?? throw new ArgumentNullException(nameof(factory)))();

    public static T GetValueOrDefault<T, TState>(this Optional<T> optional, Func<TState, T> factory, TState state)
        => optional.HasValue ? optional.Value : (factory ?? throw new ArgumentNullException(nameof(factory)))(state);

    public static bool TryGetValue<T>(this Optional<T> optional, [MaybeNullWhen(false)] out T value)
    {
        if (optional.HasValue)
        {
            value = optional.Value;
            return true;
        }

        value = default;
        return false;
    }
}
