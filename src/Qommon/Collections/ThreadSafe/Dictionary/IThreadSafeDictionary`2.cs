using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Qommon.Collections.ThreadSafe;

/// <summary>
///     Represents a generic thread-safe dictionary.
/// </summary>
/// <typeparam name="TKey"> The type of keys. </typeparam>
/// <typeparam name="TValue"> The type of values. </typeparam>
public interface IThreadSafeDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    where TKey : notnull
{
    /// <summary>
    ///     Gets an array containing the keys of this dictionary.
    /// </summary>
    new TKey[] Keys { get; }

    /// <summary>
    ///     Gets an array containing the values of this dictionary.
    /// </summary>
    new TValue[] Values { get; }

    /// <summary>
    ///     Gets whether this dictionary is empty.
    /// </summary>
    bool IsEmpty { get; }

    /// <summary>
    ///     Adds the specified key to this dictionary and sets its value to <paramref name="value"/>.
    /// </summary>
    /// <param name="key"> The key to add. </param>
    /// <param name="value"> The value of the key. </param>
    /// <returns>
    ///     <see langword="true"/> if the key was added.
    /// </returns>
    /// <exception cref="ArgumentNullException"> Thrown when <paramref name="key"/> is null. </exception>
    bool TryAdd(TKey key, TValue value);

    /// <summary>
    ///     Gets the value of the specified key from this dictionary
    ///     or adds it and sets its value to <paramref name="value"/>.
    /// </summary>
    /// <param name="key"> The key to get or add. </param>
    /// <param name="value"> The value of the key. </param>
    /// <returns>
    ///     The value of the key.
    /// </returns>
    /// <exception cref="ArgumentNullException"> Thrown when <paramref name="key"/> is null. </exception>
    TValue GetOrAdd(TKey key, TValue value);

    /// <summary>
    ///     Gets the value of the specified key from this dictionary
    ///     or adds it and sets its value to the result of invoking <paramref name="valueFactory"/>.
    /// </summary>
    /// <param name="key"> The key to get or add. </param>
    /// <param name="valueFactory"> The value of the key. </param>
    /// <returns>
    ///     The value of the key.
    /// </returns>
    /// <exception cref="ArgumentNullException"> Thrown when <paramref name="key"/> or <paramref name="valueFactory"/> is null. </exception>
    TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory);

    /// <summary>
    ///     Gets the value of the specified key from this dictionary
    ///     or adds it and sets its value to the result of invoking <paramref name="valueFactory"/>.
    /// </summary>
    /// <param name="key"> The key to get or add. </param>
    /// <param name="valueFactory"> The factory producing the value of the key. </param>
    /// <param name="state"> The state passed to the factory. </param>
    /// <returns>
    ///     The value of the key.
    /// </returns>
    /// <exception cref="ArgumentNullException"> Thrown when <paramref name="key"/> or <paramref name="valueFactory"/> is null. </exception>
    TValue GetOrAdd<TState>(TKey key, Func<TKey, TState, TValue> valueFactory, TState state);

    /// <summary>
    ///     Adds the specified key to this dictionary and sets its value to <paramref name="addValue"/>
    ///     or updates it and sets its value to the result of invoking <paramref name="updateValueFactory"/>.
    /// </summary>
    /// <param name="key"> The key to add or update. </param>
    /// <param name="addValue"> The value of the key. </param>
    /// <param name="updateValueFactory"> The factory producing the value of the key. </param>
    /// <returns>
    ///     The value of the key.
    /// </returns>
    /// <exception cref="ArgumentNullException"> Thrown when <paramref name="key"/> or <paramref name="updateValueFactory"/> is null. </exception>
    TValue AddOrUpdate(TKey key, TValue addValue, Func<TKey, TValue, TValue> updateValueFactory);

    /// <summary>
    ///     Adds the specified key to this dictionary and sets its value to the result of invoking <paramref name="addValueFactory"/>
    ///     or updates it and sets its value to the result of invoking <paramref name="updateValueFactory"/>.
    /// </summary>
    /// <param name="key"> The key to add or update. </param>
    /// <param name="addValueFactory"> The factory producing the value of the key. </param>
    /// <param name="updateValueFactory"> The factory producing the value of the key. </param>
    /// <returns>
    ///     The value of the key.
    /// </returns>
    /// <exception cref="ArgumentNullException"> Thrown when <paramref name="key"/>, <paramref name="addValueFactory"/>, or <paramref name="updateValueFactory"/> is null. </exception>
    TValue AddOrUpdate(TKey key, Func<TKey, TValue> addValueFactory, Func<TKey, TValue, TValue> updateValueFactory);

    /// <summary>
    ///     Adds the specified key to this dictionary and sets its value to the result of invoking <paramref name="addValueFactory"/>
    ///     or updates it and sets its value to the result of invoking <paramref name="updateValueFactory"/>.
    /// </summary>
    /// <param name="key"> The key to add or update. </param>
    /// <param name="addValueFactory"> The factory producing the value of the key. </param>
    /// <param name="updateValueFactory"> The factory producing the value of the key. </param>
    /// <param name="state"> The state passed to the factories. </param>
    /// <returns>
    ///     The value of the key.
    /// </returns>
    /// <exception cref="ArgumentNullException"> Thrown when <paramref name="key"/>, <paramref name="addValueFactory"/>, or <paramref name="updateValueFactory"/> is null. </exception>
    TValue AddOrUpdate<TState>(TKey key, Func<TKey, TState, TValue> addValueFactory, Func<TKey, TValue, TState, TValue> updateValueFactory, TState state);

    /// <summary>
    ///     Updates the value associated with the specified key in this dictionary to <paramref name="newValue"/>
    ///     if the existing value is equal to <paramref name="comparisonValue"/>.
    /// </summary>
    /// <param name="key"> The key whose value to update. </param>
    /// <param name="newValue"> The value that replaces the previous value of the key if the comparison results in equality. </param>
    /// <param name="comparisonValue"> The value that is compared to the value of the key. </param>
    /// <returns>
    ///     <see langword="true"/> if the value of the specified key was equal to <paramref name="comparisonValue"/>
    ///     and was replaced with <paramref name="newValue"/>.
    /// </returns>
    /// <exception cref="ArgumentNullException"> Thrown when <paramref name="key"/> is null. </exception>
    bool TryUpdate(TKey key, TValue newValue, TValue comparisonValue);

    /// <summary>
    ///     Removes the specified key from this dictionary and assigns its value to <paramref name="value"/>.
    /// </summary>
    /// <param name="key"> The key to remove. </param>
    /// <param name="value"> The output value of the removed key. </param>
    /// <returns>
    ///     <see langword="true"/> if the key was found and removed.
    /// </returns>
    /// <exception cref="ArgumentNullException"> Thrown when <paramref name="key"/> is null. </exception>
    bool TryRemove(TKey key, [MaybeNullWhen(false)] out TValue value);

    /// <summary>
    ///     Returns the contents of this dictionary as a key/value pair array.
    /// </summary>
    /// <returns>
    ///     The key/value pair array.
    /// </returns>
    KeyValuePair<TKey, TValue>[] ToArray();
}
