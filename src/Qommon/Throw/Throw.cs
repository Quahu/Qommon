using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace Qommon
{
    /// <summary>
    /// Helper methods to efficiently throw exceptions.
    /// </summary>
    [StackTraceHidden]
    public static partial class Throw
    {
        /// <summary>
        /// Throws a new <see cref="System.ArrayTypeMismatchException"/>.
        /// </summary>
        /// <exception cref="System.ArrayTypeMismatchException">Thrown with no parameters.</exception>
        [DoesNotReturn]
        public static void ArrayTypeMismatchException()
            => throw new ArrayTypeMismatchException();

        /// <summary>
        /// Throws a new <see cref="System.ArrayTypeMismatchException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <exception cref="System.ArrayTypeMismatchException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void ArrayTypeMismatchException(string message)
            => throw new ArrayTypeMismatchException(message);

        /// <summary>
        /// Throws a new <see cref="System.ArrayTypeMismatchException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
        /// <exception cref="System.ArrayTypeMismatchException">Thrown with the specified parameters.</exception>
        [DoesNotReturn]
        public static void ArrayTypeMismatchException(string message, Exception innerException)
            => throw new ArrayTypeMismatchException(message, innerException);

        /// <summary>
        /// Throws a new <see cref="System.ArgumentException"/>.
        /// </summary>
        /// <exception cref="System.ArgumentException">Thrown with no parameters.</exception>
        [DoesNotReturn]
        public static void ArgumentException()
            => throw new ArgumentException();

        /// <summary>
        /// Throws a new <see cref="System.ArgumentException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <exception cref="System.ArgumentException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void ArgumentException(string message)
            => throw new ArgumentException(message);

        /// <summary>
        /// Throws a new <see cref="System.ArgumentException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
        /// <exception cref="System.ArgumentException">Thrown with the specified parameters.</exception>
        [DoesNotReturn]
        public static void ArgumentException(string message, Exception innerException)
            => throw new ArgumentException(message, innerException);

        /// <summary>
        /// Throws a new <see cref="System.ArgumentException"/>.
        /// </summary>
        /// <param name="name">The argument name.</param>
        /// <param name="message">The message to include in the exception.</param>
        /// <exception cref="System.ArgumentException">Thrown with the specified parameters.</exception>
        [DoesNotReturn]
        public static void ArgumentException(string name, string message)
            => throw new ArgumentException(message, name);

        /// <summary>
        /// Throws a new <see cref="System.ArgumentException"/>.
        /// </summary>
        /// <param name="name">The argument name.</param>
        /// <param name="message">The message to include in the exception.</param>
        /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
        /// <exception cref="System.ArgumentException">Thrown with the specified parameters.</exception>
        [DoesNotReturn]
        public static void ArgumentException(string name, string message, Exception innerException)
            => throw new ArgumentException(message, name, innerException);

        /// <summary>
        /// Throws a new <see cref="System.ArgumentNullException"/>.
        /// </summary>
        /// <exception cref="System.ArgumentNullException">Thrown with no parameters.</exception>
        [DoesNotReturn]
        public static void ArgumentNullException()
            => throw new ArgumentNullException();

        /// <summary>
        /// Throws a new <see cref="System.ArgumentNullException"/>.
        /// </summary>
        /// <param name="name">The argument name.</param>
        /// <exception cref="System.ArgumentNullException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void ArgumentNullException(string name)
            => throw new ArgumentNullException(name);

        /// <summary>
        /// Throws a new <see cref="System.ArgumentNullException"/>.
        /// </summary>
        /// <param name="name">The argument name.</param>
        /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
        /// <exception cref="System.ArgumentNullException">Thrown with the specified parameters.</exception>
        [DoesNotReturn]
        public static void ArgumentNullException(string name, Exception innerException)
            => throw new ArgumentNullException(name, innerException);

        /// <summary>
        /// Throws a new <see cref="System.ArgumentNullException"/>.
        /// </summary>
        /// <param name="name">The argument name.</param>
        /// <param name="message">The message to include in the exception.</param>
        /// <exception cref="System.ArgumentNullException">Thrown with the specified parameters.</exception>
        [DoesNotReturn]
        public static void ArgumentNullException(string name, string message)
            => throw new ArgumentNullException(name, message);

        /// <summary>
        /// Throws a new <see cref="System.ArgumentOutOfRangeException"/>.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown with no parameters.</exception>
        [DoesNotReturn]
        public static void ArgumentOutOfRangeException()
            => throw new ArgumentOutOfRangeException();

        /// <summary>
        /// Throws a new <see cref="System.ArgumentOutOfRangeException"/>.
        /// </summary>
        /// <param name="name">The argument name.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void ArgumentOutOfRangeException(string name)
            => throw new ArgumentOutOfRangeException(name);

        /// <summary>
        /// Throws a new <see cref="System.ArgumentOutOfRangeException"/>.
        /// </summary>
        /// <param name="name">The argument name.</param>
        /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void ArgumentOutOfRangeException(string name, Exception innerException)
            => throw new ArgumentOutOfRangeException(name, innerException);

        /// <summary>
        /// Throws a new <see cref="System.ArgumentOutOfRangeException"/>.
        /// </summary>
        /// <param name="name">The argument name.</param>
        /// <param name="message">The message to include in the exception.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown with the specified parameters.</exception>
        [DoesNotReturn]
        public static void ArgumentOutOfRangeException(string name, string message)
            => throw new ArgumentOutOfRangeException(name, message);

        /// <summary>
        /// Throws a new <see cref="System.ArgumentOutOfRangeException"/>.
        /// </summary>
        /// <param name="name">The argument name.</param>
        /// <param name="value">The current argument value.</param>
        /// <param name="message">The message to include in the exception.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown with the specified parameters.</exception>
        [DoesNotReturn]
        public static void ArgumentOutOfRangeException(string name, object value, string message)
            => throw new ArgumentOutOfRangeException(name, value, message);

        /// <summary>
        /// Throws a new <see cref="System.Runtime.InteropServices.COMException"/>.
        /// </summary>
        /// <exception cref="System.Runtime.InteropServices.COMException">Thrown with no parameters.</exception>
        [DoesNotReturn]
        public static void COMException()
            => throw new COMException();

        /// <summary>
        /// Throws a new <see cref="System.Runtime.InteropServices.COMException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <exception cref="System.Runtime.InteropServices.COMException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void COMException(string message)
            => throw new COMException(message);

        /// <summary>
        /// Throws a new <see cref="System.Runtime.InteropServices.COMException"/>.
        /// </summary>
        /// <param name="message">The argument name.</param>
        /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
        /// <exception cref="System.Runtime.InteropServices.COMException">Thrown with the specified parameters.</exception>
        [DoesNotReturn]
        public static void COMException(string message, Exception innerException)
            => throw new COMException(message, innerException);

        /// <summary>
        /// Throws a new <see cref="System.Runtime.InteropServices.COMException"/>.
        /// </summary>
        /// <param name="message">The argument name.</param>
        /// <param name="error">The HRESULT of the error to include.</param>
        /// <exception cref="System.Runtime.InteropServices.COMException">Thrown with the specified parameters.</exception>
        [DoesNotReturn]
        public static void COMException(string message, int error)
            => throw new COMException(message, error);

        /// <summary>
        /// Throws a new <see cref="System.Runtime.InteropServices.ExternalException"/>.
        /// </summary>
        /// <exception cref="System.Runtime.InteropServices.ExternalException">Thrown with no parameters.</exception>
        [DoesNotReturn]
        public static void ExternalException()
            => throw new ExternalException();

        /// <summary>
        /// Throws a new <see cref="System.Runtime.InteropServices.ExternalException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <exception cref="System.Runtime.InteropServices.ExternalException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void ExternalException(string message)
            => throw new ExternalException(message);

        /// <summary>
        /// Throws a new <see cref="System.Runtime.InteropServices.ExternalException"/>.
        /// </summary>
        /// <param name="message">The argument name.</param>
        /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
        /// <exception cref="System.Runtime.InteropServices.ExternalException">Thrown with the specified parameters.</exception>
        [DoesNotReturn]
        public static void ExternalException(string message, Exception innerException)
            => throw new ExternalException(message, innerException);

        /// <summary>
        /// Throws a new <see cref="System.Runtime.InteropServices.ExternalException"/>.
        /// </summary>
        /// <param name="message">The argument name.</param>
        /// <param name="error">The HRESULT of the error to include.</param>
        /// <exception cref="System.Runtime.InteropServices.ExternalException">Thrown with the specified parameters.</exception>
        [DoesNotReturn]
        public static void ExternalException(string message, int error)
            => throw new ExternalException(message, error);

        /// <summary>
        /// Throws a new <see cref="System.FormatException"/>.
        /// </summary>
        /// <exception cref="System.FormatException">Thrown with no parameters.</exception>
        [DoesNotReturn]
        public static void FormatException()
            => throw new FormatException();

        /// <summary>
        /// Throws a new <see cref="System.FormatException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <exception cref="System.FormatException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void FormatException(string message)
            => throw new FormatException(message);

        /// <summary>
        /// Throws a new <see cref="System.FormatException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
        /// <exception cref="System.FormatException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void FormatException(string message, Exception innerException)
            => throw new FormatException(message, innerException);

        /// <summary>
        /// Throws a new <see cref="System.InsufficientMemoryException"/>.
        /// </summary>
        /// <exception cref="System.InsufficientMemoryException">Thrown with no parameters.</exception>
        [DoesNotReturn]
        public static void InsufficientMemoryException()
            => throw new InsufficientMemoryException();

        /// <summary>
        /// Throws a new <see cref="System.InsufficientMemoryException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <exception cref="System.InsufficientMemoryException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void InsufficientMemoryException(string message)
            => throw new InsufficientMemoryException(message);

        /// <summary>
        /// Throws a new <see cref="System.InsufficientMemoryException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
        /// <exception cref="System.InsufficientMemoryException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void InsufficientMemoryException(string message, Exception innerException)
            => throw new InsufficientMemoryException(message, innerException);

        /// <summary>
        /// Throws a new <see cref="System.IO.InvalidDataException"/>.
        /// </summary>
        /// <exception cref="System.IO.InvalidDataException">Thrown with no parameters.</exception>
        [DoesNotReturn]
        public static void InvalidDataException()
            => throw new InvalidDataException();

        /// <summary>
        /// Throws a new <see cref="System.IO.InvalidDataException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <exception cref="System.IO.InvalidDataException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void InvalidDataException(string message)
            => throw new InvalidDataException(message);

        /// <summary>
        /// Throws a new <see cref="System.IO.InvalidDataException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
        /// <exception cref="System.IO.InvalidDataException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void InvalidDataException(string message, Exception innerException)
            => throw new InvalidDataException(message, innerException);

        /// <summary>
        /// Throws a new <see cref="System.InvalidOperationException"/>.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown with no parameters.</exception>
        [DoesNotReturn]
        public static void InvalidOperationException()
            => throw new InvalidOperationException();

        /// <summary>
        /// Throws a new <see cref="System.InvalidOperationException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <exception cref="System.InvalidOperationException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void InvalidOperationException(string message)
            => throw new InvalidOperationException(message);

        /// <summary>
        /// Throws a new <see cref="System.InvalidOperationException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
        /// <exception cref="System.InvalidOperationException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void InvalidOperationException(string message, Exception innerException)
            => throw new InvalidOperationException(message, innerException);

        /// <summary>
        /// Throws a new <see cref="System.Threading.LockRecursionException"/>.
        /// </summary>
        /// <exception cref="System.Threading.LockRecursionException">Thrown with no parameters.</exception>
        [DoesNotReturn]
        public static void LockRecursionException()
            => throw new LockRecursionException();

        /// <summary>
        /// Throws a new <see cref="System.Threading.LockRecursionException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <exception cref="System.Threading.LockRecursionException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void LockRecursionException(string message)
            => throw new LockRecursionException(message);

        /// <summary>
        /// Throws a new <see cref="System.Threading.LockRecursionException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
        /// <exception cref="System.Threading.LockRecursionException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void LockRecursionException(string message, Exception innerException)
            => throw new LockRecursionException(message, innerException);

        /// <summary>
        /// Throws a new <see cref="System.MissingFieldException"/>.
        /// </summary>
        /// <exception cref="System.MissingFieldException">Thrown with no parameters.</exception>
        [DoesNotReturn]
        public static void MissingFieldException()
            => throw new MissingFieldException();

        /// <summary>
        /// Throws a new <see cref="System.MissingFieldException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <exception cref="System.MissingFieldException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void MissingFieldException(string message)
            => throw new MissingFieldException(message);

        /// <summary>
        /// Throws a new <see cref="System.MissingFieldException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
        /// <exception cref="System.MissingFieldException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void MissingFieldException(string message, Exception innerException)
            => throw new MissingFieldException(message, innerException);

        /// <summary>
        /// Throws a new <see cref="System.MissingFieldException"/>.
        /// </summary>
        /// <param name="className">The target class being inspected.</param>
        /// <param name="fieldName">The target field being retrieved.</param>
        /// <exception cref="System.MissingFieldException">Thrown with the specified parameters.</exception>
        [DoesNotReturn]
        public static void MissingFieldException(string className, string fieldName)
            => throw new MissingFieldException(className, fieldName);

        /// <summary>
        /// Throws a new <see cref="System.MissingMemberException"/>.
        /// </summary>
        /// <exception cref="System.MissingMemberException">Thrown with no parameters.</exception>
        [DoesNotReturn]
        public static void MissingMemberException()
            => throw new MissingMemberException();

        /// <summary>
        /// Throws a new <see cref="System.MissingMemberException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <exception cref="System.MissingMemberException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void MissingMemberException(string message)
            => throw new MissingMemberException(message);

        /// <summary>
        /// Throws a new <see cref="System.MissingMemberException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
        /// <exception cref="System.MissingMemberException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void MissingMemberException(string message, Exception innerException)
            => throw new MissingMemberException(message, innerException);

        /// <summary>
        /// Throws a new <see cref="System.MissingMemberException"/>.
        /// </summary>
        /// <param name="className">The target class being inspected.</param>
        /// <param name="memberName">The target member being retrieved.</param>
        /// <exception cref="System.MissingMemberException">Thrown with the specified parameters.</exception>
        [DoesNotReturn]
        public static void MissingMemberException(string className, string memberName)
            => throw new MissingMemberException(className, memberName);

        /// <summary>
        /// Throws a new <see cref="System.MissingMethodException"/>.
        /// </summary>
        /// <exception cref="System.MissingMethodException">Thrown with no parameters.</exception>
        [DoesNotReturn]
        public static void MissingMethodException()
            => throw new MissingMethodException();

        /// <summary>
        /// Throws a new <see cref="System.MissingMethodException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <exception cref="System.MissingMethodException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void MissingMethodException(string message)
            => throw new MissingMethodException(message);

        /// <summary>
        /// Throws a new <see cref="System.MissingMethodException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
        /// <exception cref="System.MissingMethodException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void MissingMethodException(string message, Exception innerException)
            => throw new MissingMethodException(message, innerException);

        /// <summary>
        /// Throws a new <see cref="System.MissingMethodException"/>.
        /// </summary>
        /// <param name="className">The target class being inspected.</param>
        /// <param name="methodName">The target method being retrieved.</param>
        /// <exception cref="System.MissingMethodException">Thrown with the specified parameters.</exception>
        [DoesNotReturn]
        public static void MissingMethodException(string className, string methodName)
            => throw new MissingMethodException(className, methodName);

        /// <summary>
        /// Throws a new <see cref="System.NotSupportedException"/>.
        /// </summary>
        /// <exception cref="System.NotSupportedException">Thrown with no parameters.</exception>
        [DoesNotReturn]
        public static void NotSupportedException()
            => throw new NotSupportedException();

        /// <summary>
        /// Throws a new <see cref="System.NotSupportedException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <exception cref="System.NotSupportedException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void NotSupportedException(string message)
            => throw new NotSupportedException(message);

        /// <summary>
        /// Throws a new <see cref="System.NotSupportedException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
        /// <exception cref="System.NotSupportedException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void NotSupportedException(string message, Exception innerException)
            => throw new NotSupportedException(message, innerException);

        /// <summary>
        /// Throws a new <see cref="System.ObjectDisposedException"/>.
        /// </summary>
        /// <param name="objectName">The name of the disposed object.</param>
        /// <exception cref="System.ObjectDisposedException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void ObjectDisposedException(string objectName)
            => throw new ObjectDisposedException(objectName);

        /// <summary>
        /// Throws a new <see cref="System.ObjectDisposedException"/>.
        /// </summary>
        /// <param name="objectName">The name of the disposed object.</param>
        /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
        /// <exception cref="System.ObjectDisposedException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void ObjectDisposedException(string objectName, Exception innerException)
            => throw new ObjectDisposedException(objectName, innerException);

        /// <summary>
        /// Throws a new <see cref="System.ObjectDisposedException"/>.
        /// </summary>
        /// <param name="objectName">The name of the disposed object.</param>
        /// <param name="message">The message to include in the exception.</param>
        /// <exception cref="System.ObjectDisposedException">Thrown with the specified parameters.</exception>
        [DoesNotReturn]
        public static void ObjectDisposedException(string objectName, string message)
            => throw new ObjectDisposedException(objectName, message);

        /// <summary>
        /// Throws a new <see cref="System.OperationCanceledException"/>.
        /// </summary>
        /// <exception cref="System.OperationCanceledException">Thrown with no parameters.</exception>
        [DoesNotReturn]
        public static void OperationCanceledException()
            => throw new OperationCanceledException();

        /// <summary>
        /// Throws a new <see cref="System.OperationCanceledException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <exception cref="System.OperationCanceledException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void OperationCanceledException(string message)
            => throw new OperationCanceledException(message);

        /// <summary>
        /// Throws a new <see cref="System.OperationCanceledException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
        /// <exception cref="System.OperationCanceledException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void OperationCanceledException(string message, Exception innerException)
            => throw new OperationCanceledException(message, innerException);

        /// <summary>
        /// Throws a new <see cref="System.OperationCanceledException"/>.
        /// </summary>
        /// <param name="token">The <see cref="CancellationToken"/> in use.</param>
        /// <exception cref="System.OperationCanceledException">Thrown with the specified parameters.</exception>
        [DoesNotReturn]
        public static void OperationCanceledException(CancellationToken token)
            => throw new OperationCanceledException(token);

        /// <summary>
        /// Throws a new <see cref="System.OperationCanceledException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <param name="token">The <see cref="CancellationToken"/> in use.</param>
        /// <exception cref="System.OperationCanceledException">Thrown with the specified parameters.</exception>
        [DoesNotReturn]
        public static void OperationCanceledException(string message, CancellationToken token)
            => throw new OperationCanceledException(message, token);

        /// <summary>
        /// Throws a new <see cref="System.OperationCanceledException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
        /// <param name="token">The <see cref="CancellationToken"/> in use.</param>
        /// <exception cref="System.OperationCanceledException">Thrown with the specified parameters.</exception>
        [DoesNotReturn]
        public static void OperationCanceledException(string message, Exception innerException, CancellationToken token)
            => throw new OperationCanceledException(message, innerException, token);

        /// <summary>
        /// Throws a new <see cref="System.PlatformNotSupportedException"/>.
        /// </summary>
        /// <exception cref="System.PlatformNotSupportedException">Thrown with no parameters.</exception>
        [DoesNotReturn]
        public static void PlatformNotSupportedException()
            => throw new PlatformNotSupportedException();

        /// <summary>
        /// Throws a new <see cref="System.PlatformNotSupportedException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <exception cref="System.PlatformNotSupportedException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void PlatformNotSupportedException(string message)
            => throw new PlatformNotSupportedException(message);

        /// <summary>
        /// Throws a new <see cref="System.PlatformNotSupportedException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
        /// <exception cref="System.PlatformNotSupportedException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void PlatformNotSupportedException(string message, Exception innerException)
            => throw new PlatformNotSupportedException(message, innerException);

        /// <summary>
        /// Throws a new <see cref="System.Threading.SynchronizationLockException"/>.
        /// </summary>
        /// <exception cref="System.Threading.SynchronizationLockException">Thrown with no parameters.</exception>
        [DoesNotReturn]
        public static void SynchronizationLockException()
            => throw new SynchronizationLockException();

        /// <summary>
        /// Throws a new <see cref="System.Threading.SynchronizationLockException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <exception cref="System.Threading.SynchronizationLockException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void SynchronizationLockException(string message)
            => throw new SynchronizationLockException(message);

        /// <summary>
        /// Throws a new <see cref="System.Threading.SynchronizationLockException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
        /// <exception cref="System.Threading.SynchronizationLockException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void SynchronizationLockException(string message, Exception innerException)
            => throw new SynchronizationLockException(message, innerException);

        /// <summary>
        /// Throws a new <see cref="System.TimeoutException"/>.
        /// </summary>
        /// <exception cref="System.TimeoutException">Thrown with no parameters.</exception>
        [DoesNotReturn]
        public static void TimeoutException()
            => throw new TimeoutException();

        /// <summary>
        /// Throws a new <see cref="System.TimeoutException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <exception cref="System.TimeoutException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void TimeoutException(string message)
            => throw new TimeoutException(message);

        /// <summary>
        /// Throws a new <see cref="System.TimeoutException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
        /// <exception cref="System.TimeoutException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void TimeoutException(string message, Exception innerException)
            => throw new TimeoutException(message, innerException);

        /// <summary>
        /// Throws a new <see cref="System.UnauthorizedAccessException"/>.
        /// </summary>
        /// <exception cref="System.UnauthorizedAccessException">Thrown with no parameters.</exception>
        [DoesNotReturn]
        public static void UnauthorizedAccessException()
            => throw new UnauthorizedAccessException();

        /// <summary>
        /// Throws a new <see cref="System.UnauthorizedAccessException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <exception cref="System.UnauthorizedAccessException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void UnauthorizedAccessException(string message)
            => throw new UnauthorizedAccessException(message);

        /// <summary>
        /// Throws a new <see cref="System.UnauthorizedAccessException"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
        /// <exception cref="System.UnauthorizedAccessException">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void UnauthorizedAccessException(string message, Exception innerException)
            => throw new UnauthorizedAccessException(message, innerException);

        /// <summary>
        /// Throws a new <see cref="System.ComponentModel.Win32Exception"/>.
        /// </summary>
        /// <exception cref="System.ComponentModel.Win32Exception">Thrown with no parameters.</exception>
        [DoesNotReturn]
        public static void Win32Exception()
            => throw new Win32Exception();

        /// <summary>
        /// Throws a new <see cref="System.ComponentModel.Win32Exception"/>.
        /// </summary>
        /// <param name="error">The Win32 error code associated with this exception.</param>
        /// <exception cref="System.ComponentModel.Win32Exception">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void Win32Exception(int error)
            => throw new Win32Exception(error);

        /// <summary>
        /// Throws a new <see cref="System.ComponentModel.Win32Exception"/>.
        /// </summary>
        /// <param name="error">The Win32 error code associated with this exception.</param>
        /// <param name="message">The message to include in the exception.</param>
        /// <exception cref="System.ComponentModel.Win32Exception">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void Win32Exception(int error, string message)
            => throw new Win32Exception(error, message);

        /// <summary>
        /// Throws a new <see cref="System.ComponentModel.Win32Exception"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <exception cref="System.ComponentModel.Win32Exception">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void Win32Exception(string message)
            => throw new Win32Exception(message);

        /// <summary>
        /// Throws a new <see cref="System.ComponentModel.Win32Exception"/>.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <param name="innerException">The inner <see cref="System.Exception"/> to include.</param>
        /// <exception cref="System.ComponentModel.Win32Exception">Thrown with the specified parameter.</exception>
        [DoesNotReturn]
        public static void Win32Exception(string message, Exception innerException)
            => throw new Win32Exception(message, innerException);
    }
}
