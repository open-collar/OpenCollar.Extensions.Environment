using System;
using System.Runtime.Serialization;

using JetBrains.Annotations;

using OpenCollar.Extensions.Validation;

namespace OpenCollar.Extensions.Environment
{
    /// <summary>
    ///     An exception that represents a mismatch in environments (between the application environment and a resource
    ///     that the application depends upon).
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public sealed class MismatchedEnvironmentException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MismatchedEnvironmentException"> </see> class.
        /// </summary>
        public MismatchedEnvironmentException()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MismatchedEnvironmentException"> </see> class with a
        ///     specified error message.
        /// </summary>
        /// <param name="message">
        ///     The message that describes the error.
        /// </param>
        public MismatchedEnvironmentException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MismatchedEnvironmentException"> </see> class with a
        ///     specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">
        ///     The error message that explains the reason for the exception.
        /// </param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception, or <see langword="null" /> if no inner
        ///     exception is specified.
        /// </param>
        public MismatchedEnvironmentException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MismatchedEnvironmentException"> </see> class with
        ///     serialized data.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="System.Runtime.Serialization.SerializationInfo"> </see> that holds the serialized object
        ///     data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="System.Runtime.Serialization.StreamingContext"> </see> that contains contextual
        ///     information about the source or destination.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        ///     The <paramref name="info"> info </paramref> parameter is <see langword="null" />.
        /// </exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException">
        ///     The class name is null or <see cref="System.Exception.HResult"> </see> is zero (0).
        /// </exception>
        private MismatchedEnvironmentException([NotNull] SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.Validate(nameof(info), ObjectIs.NotNull);

            ApplicationEnvironment = info.GetString(nameof(ApplicationEnvironment));
            ResourceEnvironment = info.GetString(nameof(ResourceEnvironment));
        }

        /// <summary>
        ///     Gets the application environment.
        /// </summary>
        /// <value>
        ///     The environment name for the host application, e.g. "PDN", "UAT" or "DEV" - this is left up to the
        ///     implementing application. <see langword="null" /> will be returned if the value could not be determined.
        ///     Environment names are always treated as case insensitive.
        /// </value>
        public string? ApplicationEnvironment { get; set; }

        /// <summary>
        ///     Gets the resource environment.
        /// </summary>
        /// <value>
        ///     The environment name for the resource at fault, e.g. "PDN", "UAT" or "DEV" - this is left up to the
        ///     implementing application. <see langword="null" /> will be returned if the value could not be determined.
        ///     Environment names are always treated as case insensitive.
        /// </value>
        public string? ResourceEnvironment { get; set; }

        /// <summary>
        ///     When overridden in a derived class, sets the
        ///     <see cref="System.Runtime.Serialization.SerializationInfo" /> with information about the exception.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data
        ///     about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="System.Runtime.Serialization.StreamingContext" /> that contains contextual information
        ///     about the source or destination.
        /// </param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.Validate(nameof(info), ObjectIs.NotNull);

            info.AddValue(nameof(ApplicationEnvironment), ApplicationEnvironment);
            info.AddValue(nameof(ResourceEnvironment), ResourceEnvironment);
            base.GetObjectData(info, context);
        }
    }
}