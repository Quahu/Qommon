using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace Qommon;

public static partial class Throw
{
    /// <summary>
    /// Throws a new <see cref="System.ArrayTypeMismatchException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <exception cref="System.ArrayTypeMismatchException">Thrown with no parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T ArrayTypeMismatchException<T>()
        => throw new ArrayTypeMismatchException();

    /// <summary>
    /// Throws a new <see cref="System.ArrayTypeMismatchException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <exception cref="System.ArrayTypeMismatchException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T ArrayTypeMismatchException<T>(string? message)
        => throw new ArrayTypeMismatchException(message);

    /// <summary>
    /// Throws a new <see cref="System.ArrayTypeMismatchException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
    /// <exception cref="System.ArrayTypeMismatchException">Thrown with the specified parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T ArrayTypeMismatchException<T>(string? message, Exception? innerException)
        => throw new ArrayTypeMismatchException(message, innerException);

    /// <summary>
    /// Throws a new <see cref="System.ArgumentException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <exception cref="System.ArgumentException">Thrown with no parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T ArgumentException<T>()
        => throw new ArgumentException();

    /// <summary>
    /// Throws a new <see cref="System.ArgumentException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <exception cref="System.ArgumentException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T ArgumentException<T>(string? message)
        => throw new ArgumentException(message);

    /// <summary>
    /// Throws a new <see cref="System.ArgumentException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
    /// <exception cref="System.ArgumentException">Thrown with the specified parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T ArgumentException<T>(string? message, Exception? innerException)
        => throw new ArgumentException(message, innerException);

    /// <summary>
    /// Throws a new <see cref="System.ArgumentException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="name">The argument name.</param>
    /// <param name="message">The message to include in the exception.</param>
    /// <exception cref="System.ArgumentException">Thrown with the specified parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T ArgumentException<T>(string? message, string? name)
        => throw new ArgumentException(message, name);

    /// <summary>
    /// Throws a new <see cref="System.ArgumentException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="name">The argument name.</param>
    /// <param name="message">The message to include in the exception.</param>
    /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
    /// <exception cref="System.ArgumentException">Thrown with the specified parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T ArgumentException<T>(string? message, string? name, Exception? innerException)
        => throw new ArgumentException(message, name, innerException);

    /// <summary>
    /// Throws a new <see cref="System.ArgumentNullException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <exception cref="System.ArgumentNullException">Thrown with no parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T ArgumentNullException<T>()
        => throw new ArgumentNullException();

    /// <summary>
    /// Throws a new <see cref="System.ArgumentNullException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="name">The argument name.</param>
    /// <exception cref="System.ArgumentNullException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T ArgumentNullException<T>(string? name)
        => throw new ArgumentNullException(name);

    /// <summary>
    /// Throws a new <see cref="System.ArgumentNullException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="name">The argument name.</param>
    /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
    /// <exception cref="System.ArgumentNullException">Thrown with the specified parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T ArgumentNullException<T>(string? name, Exception? innerException)
        => throw new ArgumentNullException(name, innerException);

    /// <summary>
    /// Throws a new <see cref="System.ArgumentNullException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="name">The argument name.</param>
    /// <param name="message">The message to include in the exception.</param>
    /// <exception cref="System.ArgumentNullException">Thrown with the specified parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T ArgumentNullException<T>(string? name, string? message)
        => throw new ArgumentNullException(name, message);

    /// <summary>
    /// Throws a new <see cref="System.ArgumentOutOfRangeException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <exception cref="System.ArgumentOutOfRangeException">Thrown with no parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T ArgumentOutOfRangeException<T>()
        => throw new ArgumentOutOfRangeException();

    /// <summary>
    /// Throws a new <see cref="System.ArgumentOutOfRangeException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="name">The argument name.</param>
    /// <exception cref="System.ArgumentOutOfRangeException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T ArgumentOutOfRangeException<T>(string? name)
        => throw new ArgumentOutOfRangeException(name);

    /// <summary>
    /// Throws a new <see cref="System.ArgumentOutOfRangeException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="name">The argument name.</param>
    /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
    /// <exception cref="System.ArgumentOutOfRangeException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T ArgumentOutOfRangeException<T>(string? name, Exception? innerException)
        => throw new ArgumentOutOfRangeException(name, innerException);

    /// <summary>
    /// Throws a new <see cref="System.ArgumentOutOfRangeException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="name">The argument name.</param>
    /// <param name="message">The message to include in the exception.</param>
    /// <exception cref="System.ArgumentOutOfRangeException">Thrown with the specified parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T ArgumentOutOfRangeException<T>(string? name, string? message)
        => throw new ArgumentOutOfRangeException(name, message);

    /// <summary>
    /// Throws a new <see cref="System.ArgumentOutOfRangeException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="name">The argument name.</param>
    /// <param name="value">The current argument value.</param>
    /// <param name="message">The message to include in the exception.</param>
    /// <exception cref="System.ArgumentOutOfRangeException">Thrown with the specified parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T ArgumentOutOfRangeException<T>(string? name, object? value, string? message)
        => throw new ArgumentOutOfRangeException(name, value, message);

    /// <summary>
    /// Throws a new <see cref="System.Runtime.InteropServices.COMException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <exception cref="System.Runtime.InteropServices.COMException">Thrown with no parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T COMException<T>()
        => throw new COMException();

    /// <summary>
    /// Throws a new <see cref="System.Runtime.InteropServices.COMException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <exception cref="System.Runtime.InteropServices.COMException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T COMException<T>(string? message)
        => throw new COMException(message);

    /// <summary>
    /// Throws a new <see cref="System.Runtime.InteropServices.COMException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The argument name.</param>
    /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
    /// <exception cref="System.Runtime.InteropServices.COMException">Thrown with the specified parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T COMException<T>(string? message, Exception? innerException)
        => throw new COMException(message, innerException);

    /// <summary>
    /// Throws a new <see cref="System.Runtime.InteropServices.COMException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The argument name.</param>
    /// <param name="error">The HRESULT of the error to include.</param>
    /// <exception cref="System.Runtime.InteropServices.COMException">Thrown with the specified parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T COMException<T>(string? message, int error)
        => throw new COMException(message, error);

    /// <summary>
    /// Throws a new <see cref="System.Runtime.InteropServices.ExternalException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <exception cref="System.Runtime.InteropServices.ExternalException">Thrown with no parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T ExternalException<T>()
        => throw new ExternalException();

    /// <summary>
    /// Throws a new <see cref="System.Runtime.InteropServices.ExternalException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <exception cref="System.Runtime.InteropServices.ExternalException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T ExternalException<T>(string? message)
        => throw new ExternalException(message);

    /// <summary>
    /// Throws a new <see cref="System.Runtime.InteropServices.ExternalException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The argument name.</param>
    /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
    /// <exception cref="System.Runtime.InteropServices.ExternalException">Thrown with the specified parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T ExternalException<T>(string? message, Exception? innerException)
        => throw new ExternalException(message, innerException);

    /// <summary>
    /// Throws a new <see cref="System.Runtime.InteropServices.ExternalException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The argument name.</param>
    /// <param name="error">The HRESULT of the error to include.</param>
    /// <exception cref="System.Runtime.InteropServices.ExternalException">Thrown with the specified parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T ExternalException<T>(string? message, int error)
        => throw new ExternalException(message, error);

    /// <summary>
    /// Throws a new <see cref="System.FormatException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <exception cref="System.FormatException">Thrown with no parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T FormatException<T>()
        => throw new FormatException();

    /// <summary>
    /// Throws a new <see cref="System.FormatException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <exception cref="System.FormatException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T FormatException<T>(string? message)
        => throw new FormatException(message);

    /// <summary>
    /// Throws a new <see cref="System.FormatException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
    /// <exception cref="System.FormatException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T FormatException<T>(string? message, Exception? innerException)
        => throw new FormatException(message, innerException);

    /// <summary>
    /// Throws a new <see cref="System.Collections.Generic.KeyNotFoundException"/>.
    /// </summary>
    /// <exception cref="System.FormatException">Thrown with no parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T KeyNotFoundException<T>()
        => throw new KeyNotFoundException();

    /// <summary>
    /// Throws a new <see cref="System.Collections.Generic.KeyNotFoundException"/>.
    /// </summary>
    /// <param name="message">The message to include in the exception.</param>
    /// <exception cref="System.FormatException">Thrown with the specified parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T KeyNotFoundException<T>(string? message)
        => throw new KeyNotFoundException(message);

    /// <summary>
    /// Throws a new <see cref="System.Collections.Generic.KeyNotFoundException"/>.
    /// </summary>
    /// <param name="message">The message to include in the exception.</param>
    /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
    /// <exception cref="System.FormatException">Thrown with the specified parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T KeyNotFoundException<T>(string? message, Exception? innerException)
        => throw new KeyNotFoundException(message, innerException);

    /// <summary>
    /// Throws a new <see cref="System.InsufficientMemoryException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <exception cref="System.InsufficientMemoryException">Thrown with no parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T InsufficientMemoryException<T>()
        => throw new InsufficientMemoryException();

    /// <summary>
    /// Throws a new <see cref="System.InsufficientMemoryException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <exception cref="System.InsufficientMemoryException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T InsufficientMemoryException<T>(string? message)
        => throw new InsufficientMemoryException(message);

    /// <summary>
    /// Throws a new <see cref="System.InsufficientMemoryException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
    /// <exception cref="System.InsufficientMemoryException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T InsufficientMemoryException<T>(string? message, Exception? innerException)
        => throw new InsufficientMemoryException(message, innerException);

    /// <summary>
    /// Throws a new <see cref="System.IO.InvalidDataException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <exception cref="System.IO.InvalidDataException">Thrown with no parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T InvalidDataException<T>()
        => throw new InvalidDataException();

    /// <summary>
    /// Throws a new <see cref="System.IO.InvalidDataException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <exception cref="System.IO.InvalidDataException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T InvalidDataException<T>(string? message)
        => throw new InvalidDataException(message);

    /// <summary>
    /// Throws a new <see cref="System.IO.InvalidDataException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
    /// <exception cref="System.IO.InvalidDataException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T InvalidDataException<T>(string? message, Exception? innerException)
        => throw new InvalidDataException(message, innerException);

    /// <summary>
    /// Throws a new <see cref="System.InvalidOperationException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <exception cref="System.InvalidOperationException">Thrown with no parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T InvalidOperationException<T>()
        => throw new InvalidOperationException();

    /// <summary>
    /// Throws a new <see cref="System.InvalidOperationException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <exception cref="System.InvalidOperationException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T InvalidOperationException<T>(string? message)
        => throw new InvalidOperationException(message);

    /// <summary>
    /// Throws a new <see cref="System.InvalidOperationException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
    /// <exception cref="System.InvalidOperationException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T InvalidOperationException<T>(string? message, Exception? innerException)
        => throw new InvalidOperationException(message, innerException);

    /// <summary>
    /// Throws a new <see cref="System.Threading.LockRecursionException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <exception cref="System.Threading.LockRecursionException">Thrown with no parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T LockRecursionException<T>()
        => throw new LockRecursionException();

    /// <summary>
    /// Throws a new <see cref="System.Threading.LockRecursionException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <exception cref="System.Threading.LockRecursionException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T LockRecursionException<T>(string? message)
        => throw new LockRecursionException(message);

    /// <summary>
    /// Throws a new <see cref="System.Threading.LockRecursionException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
    /// <exception cref="System.Threading.LockRecursionException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T LockRecursionException<T>(string? message, Exception? innerException)
        => throw new LockRecursionException(message, innerException);

    /// <summary>
    /// Throws a new <see cref="System.MissingFieldException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <exception cref="System.MissingFieldException">Thrown with no parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T MissingFieldException<T>()
        => throw new MissingFieldException();

    /// <summary>
    /// Throws a new <see cref="System.MissingFieldException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <exception cref="System.MissingFieldException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T MissingFieldException<T>(string? message)
        => throw new MissingFieldException(message);

    /// <summary>
    /// Throws a new <see cref="System.MissingFieldException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
    /// <exception cref="System.MissingFieldException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T MissingFieldException<T>(string? message, Exception? innerException)
        => throw new MissingFieldException(message, innerException);

    /// <summary>
    /// Throws a new <see cref="System.MissingFieldException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="className">The target class being inspected.</param>
    /// <param name="fieldName">The target field being retrieved.</param>
    /// <exception cref="System.MissingFieldException">Thrown with the specified parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T MissingFieldException<T>(string className, string fieldName)
        => throw new MissingFieldException(className, fieldName);

    /// <summary>
    /// Throws a new <see cref="System.MissingMemberException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <exception cref="System.MissingMemberException">Thrown with no parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T MissingMemberException<T>()
        => throw new MissingMemberException();

    /// <summary>
    /// Throws a new <see cref="System.MissingMemberException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <exception cref="System.MissingMemberException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T MissingMemberException<T>(string? message)
        => throw new MissingMemberException(message);

    /// <summary>
    /// Throws a new <see cref="System.MissingMemberException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
    /// <exception cref="System.MissingMemberException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T MissingMemberException<T>(string? message, Exception? innerException)
        => throw new MissingMemberException(message, innerException);

    /// <summary>
    /// Throws a new <see cref="System.MissingMemberException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="className">The target class being inspected.</param>
    /// <param name="memberName">The target member being retrieved.</param>
    /// <exception cref="System.MissingMemberException">Thrown with the specified parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T MissingMemberException<T>(string className, string memberName)
        => throw new MissingMemberException(className, memberName);

    /// <summary>
    /// Throws a new <see cref="System.MissingMethodException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <exception cref="System.MissingMethodException">Thrown with no parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T MissingMethodException<T>()
        => throw new MissingMethodException();

    /// <summary>
    /// Throws a new <see cref="System.MissingMethodException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <exception cref="System.MissingMethodException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T MissingMethodException<T>(string? message)
        => throw new MissingMethodException(message);

    /// <summary>
    /// Throws a new <see cref="System.MissingMethodException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
    /// <exception cref="System.MissingMethodException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T MissingMethodException<T>(string? message, Exception? innerException)
        => throw new MissingMethodException(message, innerException);

    /// <summary>
    /// Throws a new <see cref="System.MissingMethodException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="className">The target class being inspected.</param>
    /// <param name="methodName">The target method being retrieved.</param>
    /// <exception cref="System.MissingMethodException">Thrown with the specified parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T MissingMethodException<T>(string className, string methodName)
        => throw new MissingMethodException(className, methodName);

    /// <summary>
    /// Throws a new <see cref="System.NotSupportedException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <exception cref="System.NotSupportedException">Thrown with no parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T NotSupportedException<T>()
        => throw new NotSupportedException();

    /// <summary>
    /// Throws a new <see cref="System.NotSupportedException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <exception cref="System.NotSupportedException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T NotSupportedException<T>(string? message)
        => throw new NotSupportedException(message);

    /// <summary>
    /// Throws a new <see cref="System.NotSupportedException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
    /// <exception cref="System.NotSupportedException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T NotSupportedException<T>(string? message, Exception? innerException)
        => throw new NotSupportedException(message, innerException);

    /// <summary>
    /// Throws a new <see cref="System.ObjectDisposedException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="objectName">The name of the disposed object.</param>
    /// <exception cref="System.ObjectDisposedException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T ObjectDisposedException<T>(string objectName)
        => throw new ObjectDisposedException(objectName);

    /// <summary>
    /// Throws a new <see cref="System.ObjectDisposedException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="objectName">The name of the disposed object.</param>
    /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
    /// <exception cref="System.ObjectDisposedException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T ObjectDisposedException<T>(string objectName, Exception? innerException)
        => throw new ObjectDisposedException(objectName, innerException);

    /// <summary>
    /// Throws a new <see cref="System.ObjectDisposedException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="objectName">The name of the disposed object.</param>
    /// <param name="message">The message to include in the exception.</param>
    /// <exception cref="System.ObjectDisposedException">Thrown with the specified parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T ObjectDisposedException<T>(string objectName, string? message)
        => throw new ObjectDisposedException(objectName, message);

    /// <summary>
    /// Throws a new <see cref="System.OperationCanceledException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <exception cref="System.OperationCanceledException">Thrown with no parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T OperationCanceledException<T>()
        => throw new OperationCanceledException();

    /// <summary>
    /// Throws a new <see cref="System.OperationCanceledException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <exception cref="System.OperationCanceledException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T OperationCanceledException<T>(string? message)
        => throw new OperationCanceledException(message);

    /// <summary>
    /// Throws a new <see cref="System.OperationCanceledException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
    /// <exception cref="System.OperationCanceledException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T OperationCanceledException<T>(string? message, Exception? innerException)
        => throw new OperationCanceledException(message, innerException);

    /// <summary>
    /// Throws a new <see cref="System.OperationCanceledException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="token">The <see cref="CancellationToken"/> in use.</param>
    /// <exception cref="System.OperationCanceledException">Thrown with the specified parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T OperationCanceledException<T>(CancellationToken token)
        => throw new OperationCanceledException(token);

    /// <summary>
    /// Throws a new <see cref="System.OperationCanceledException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <param name="token">The <see cref="CancellationToken"/> in use.</param>
    /// <exception cref="System.OperationCanceledException">Thrown with the specified parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T OperationCanceledException<T>(string? message, CancellationToken token)
        => throw new OperationCanceledException(message, token);

    /// <summary>
    /// Throws a new <see cref="System.OperationCanceledException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
    /// <param name="token">The <see cref="CancellationToken"/> in use.</param>
    /// <exception cref="System.OperationCanceledException">Thrown with the specified parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T OperationCanceledException<T>(string? message, Exception? innerException, CancellationToken token)
        => throw new OperationCanceledException(message, innerException, token);

    /// <summary>
    /// Throws a new <see cref="System.PlatformNotSupportedException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <exception cref="System.PlatformNotSupportedException">Thrown with no parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T PlatformNotSupportedException<T>()
        => throw new PlatformNotSupportedException();

    /// <summary>
    /// Throws a new <see cref="System.PlatformNotSupportedException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <exception cref="System.PlatformNotSupportedException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T PlatformNotSupportedException<T>(string? message)
        => throw new PlatformNotSupportedException(message);

    /// <summary>
    /// Throws a new <see cref="System.PlatformNotSupportedException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
    /// <exception cref="System.PlatformNotSupportedException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T PlatformNotSupportedException<T>(string? message, Exception? innerException)
        => throw new PlatformNotSupportedException(message, innerException);

    /// <summary>
    /// Throws a new <see cref="System.Threading.SynchronizationLockException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <exception cref="System.Threading.SynchronizationLockException">Thrown with no parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T SynchronizationLockException<T>()
        => throw new SynchronizationLockException();

    /// <summary>
    /// Throws a new <see cref="System.Threading.SynchronizationLockException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <exception cref="System.Threading.SynchronizationLockException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T SynchronizationLockException<T>(string? message)
        => throw new SynchronizationLockException(message);

    /// <summary>
    /// Throws a new <see cref="System.Threading.SynchronizationLockException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
    /// <exception cref="System.Threading.SynchronizationLockException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T SynchronizationLockException<T>(string? message, Exception? innerException)
        => throw new SynchronizationLockException(message, innerException);

    /// <summary>
    /// Throws a new <see cref="System.TimeoutException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <exception cref="System.TimeoutException">Thrown with no parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T TimeoutException<T>()
        => throw new TimeoutException();

    /// <summary>
    /// Throws a new <see cref="System.TimeoutException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <exception cref="System.TimeoutException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T TimeoutException<T>(string? message)
        => throw new TimeoutException(message);

    /// <summary>
    /// Throws a new <see cref="System.TimeoutException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
    /// <exception cref="System.TimeoutException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T TimeoutException<T>(string? message, Exception? innerException)
        => throw new TimeoutException(message, innerException);

    /// <summary>
    /// Throws a new <see cref="System.UnauthorizedAccessException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <exception cref="System.UnauthorizedAccessException">Thrown with no parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T UnauthorizedAccessException<T>()
        => throw new UnauthorizedAccessException();

    /// <summary>
    /// Throws a new <see cref="System.UnauthorizedAccessException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <exception cref="System.UnauthorizedAccessException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T UnauthorizedAccessException<T>(string? message)
        => throw new UnauthorizedAccessException(message);

    /// <summary>
    /// Throws a new <see cref="System.UnauthorizedAccessException"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
    /// <exception cref="System.UnauthorizedAccessException">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T UnauthorizedAccessException<T>(string? message, Exception? innerException)
        => throw new UnauthorizedAccessException(message, innerException);

    /// <summary>
    /// Throws a new <see cref="System.ComponentModel.Win32Exception"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <exception cref="System.ComponentModel.Win32Exception">Thrown with no parameters.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T Win32Exception<T>()
        => throw new Win32Exception();

    /// <summary>
    /// Throws a new <see cref="System.ComponentModel.Win32Exception"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="error">The Win32 error code associated with this exception.</param>
    /// <exception cref="System.ComponentModel.Win32Exception">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T Win32Exception<T>(int error)
        => throw new Win32Exception(error);

    /// <summary>
    /// Throws a new <see cref="System.ComponentModel.Win32Exception"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="error">The Win32 error code associated with this exception.</param>
    /// <param name="message">The message to include in the exception.</param>
    /// <exception cref="System.ComponentModel.Win32Exception">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T Win32Exception<T>(int error, string? message)
        => throw new Win32Exception(error, message);

    /// <summary>
    /// Throws a new <see cref="System.ComponentModel.Win32Exception"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <exception cref="System.ComponentModel.Win32Exception">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T Win32Exception<T>(string? message)
        => throw new Win32Exception(message);

    /// <summary>
    /// Throws a new <see cref="System.ComponentModel.Win32Exception"/>.
    /// </summary>
    /// <typeparam name="T">The type of expected result.</typeparam>
    /// <param name="message">The message to include in the exception.</param>
    /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
    /// <exception cref="System.ComponentModel.Win32Exception">Thrown with the specified parameter.</exception>
    /// <returns>This method always throws, so it actually never returns a value.</returns>
    [DoesNotReturn]
    public static T Win32Exception<T>(string? message, Exception? innerException)
        => throw new Win32Exception(message, innerException);
}
