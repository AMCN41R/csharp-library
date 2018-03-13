using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

namespace Library.Guards
{
    /// <summary>
    /// Provides guard clauses.
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// Guards against a null argument.
        /// </summary>
        /// <typeparam name="TArgument">The type of the argument.</typeparam>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="argument">The argument.</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="argument" /> is <c>null</c>.</exception>
        /// <remarks>
        /// <typeparamref name="TArgument" /> is restricted to reference types to avoid boxing of value type objects.
        /// </remarks>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Source package.")]
        [DebuggerStepThrough]
        public static void AgainstNullArgument<TArgument>(string parameterName, [ValidatedNotNull][NoEnumeration] TArgument argument)
            where TArgument : class
        {
            if (argument == null)
            {
                throw new ArgumentNullException(
                    parameterName,
                    string.Format(CultureInfo.InvariantCulture, "{0} is null.", parameterName));
            }
        }

        /// <summary>
        /// Guards against a null argument if <typeparamref name="TArgument" /> can be <c>null</c>.
        /// </summary>
        /// <typeparam name="TArgument">The type of the argument.</typeparam>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="argument">The argument.</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="argument" /> is <c>null</c>.</exception>
        /// <remarks>
        /// Performs a type check to avoid boxing of value type objects.
        /// </remarks>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Source package.")]
        [DebuggerStepThrough]
        public static void AgainstNullArgumentIfNullable<TArgument>(
            string parameterName,
            [ValidatedNotNull] TArgument argument)
        {
            if (typeof(TArgument).IsNullableType() && argument == null)
            {
                throw new ArgumentNullException(
                    parameterName,
                    string.Format(CultureInfo.InvariantCulture, "{0} is null.", parameterName));
            }
        }

        /// <summary>
        /// Guards against a null argument property value.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="argumentProperty">The argument property.</param>
        /// <exception cref="System.ArgumentException"><paramref name="argumentProperty" /> is <c>null</c>.</exception>
        /// <remarks>
        /// <typeparamref name="TProperty" /> is restricted to reference types to avoid boxing of value type objects.
        /// </remarks>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Source package.")]
        [DebuggerStepThrough]
        public static void AgainstNullArgumentProperty<TProperty>(
            string parameterName,
            string propertyName,
            [ValidatedNotNull] TProperty argumentProperty)
            where TProperty : class
        {
            if (argumentProperty == null)
            {
                throw new ArgumentException(
                    string.Format(CultureInfo.InvariantCulture, "{0}.{1} is null.", parameterName, propertyName),
                    parameterName);
            }
        }

        /// <summary>
        /// Guards against a null argument property value if <typeparamref name="TProperty" /> can be <c>null</c>.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="argumentProperty">The argument property.</param>
        /// <exception cref="System.ArgumentException"><paramref name="argumentProperty" /> is <c>null</c>.</exception>
        /// <remarks>
        /// Performs a type check to avoid boxing of value type objects.
        /// </remarks>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Source package.")]
        [DebuggerStepThrough]
        public static void AgainstNullArgumentPropertyIfNullable<TProperty>(
            string parameterName,
            string propertyName,
            [ValidatedNotNull] TProperty argumentProperty)
        {
            if (typeof(TProperty).IsNullableType() && argumentProperty == null)
            {
                throw new ArgumentException(
                    string.Format(CultureInfo.InvariantCulture, "{0}.{1} is null.", parameterName, propertyName),
                    parameterName);
            }
        }

        /// <summary>
        /// Guards against a null of empty string argument.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="argument">The argument.</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="argument" /> is <c>null</c>.</exception>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Source package.")]
        [DebuggerStepThrough]
        public static void AgainstNullOrEmptyArgument(string parameterName, [ValidatedNotNull] string argument)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(
                    parameterName,
                    string.Format(CultureInfo.InvariantCulture, "{0} is null.", parameterName));
            }

            if (argument == string.Empty)
            {
                throw new EmptyStringException(
                    string.Format(CultureInfo.InvariantCulture, "String cannot be empty {0}", parameterName));
            }
        }

        /// <summary>
        /// Guards against a null of empty string argument.
        /// </summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="argument">The argument.</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="argument" /> is <c>null</c>.</exception>
        /// <remarks>
        /// <typeparamref name="T" /> is restricted to reference types to avoid boxing of value type objects.
        /// </remarks>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Source package.")]
        [DebuggerStepThrough]
        public static void AgainstNullOrEmptyArgument<T>(
            string parameterName,
            [ValidatedNotNull] IEnumerable<T> argument)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(
                    parameterName,
                    string.Format(CultureInfo.InvariantCulture, "{0} is null.", parameterName));
            }

            if (!argument.Any())
            {
                throw new EmptyStringException(
                    string.Format(CultureInfo.InvariantCulture, "Collection cannot be empty {0}", parameterName));
            }
        }

        /// <summary>
        /// Guards against a null or whitespace string argument.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="argument">The argument.</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="argument" /> is <c>null</c>.</exception>
        /// <exception cref="WhitespaceException"><paramref name="argument" /> is not empty but only contains <c>whitespace</c>.</exception>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Source package.")]
        [DebuggerStepThrough]
        public static void AgainstNullOrWhitespaceArgument(string parameterName, [ValidatedNotNull] string argument)
        {
            AgainstNullOrEmptyArgument(parameterName, argument);

            if (string.IsNullOrWhiteSpace(argument))
            {
                throw new WhitespaceException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "String is not empty but only contains whitespace {0}",
                        parameterName));
            }
        }

        [DebuggerStepThrough]
        public static void AgainstStringExceedsNCharactersArgument(string parameterName, string argument, int characterLimit)
        {
            if (argument.Length > characterLimit)
            {
                throw new StringExceedsNCharactersException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "Argument {0} exceeds {1} characters",
                        parameterName, characterLimit));
            }
        }

        [DebuggerStepThrough]
        public static void AgainstNegativeValue(string parameterName, decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(
                 parameterName,
                 value,
                $"{parameterName} cannot be less than zero.");
            }
        }

        [DebuggerStepThrough]
        public static void AgainstNegativeValue(string parameterName, int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(
                    parameterName,
                    value,
                    $"{parameterName} cannot be less than zero.");
            }
        }

        [DebuggerStepThrough]
        [Obsolete("Use Guard.AgainstDefaultValue instead.")]
        public static void AgainstEmptyArgument(string parameterName, Guid argument)
        {
            if (argument == Guid.Empty)
            {
                throw new EmptyGuidException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "Argument {0} is an empty guid.",
                        parameterName));
            }
        }


        [DebuggerStepThrough]
        public static void AgainstDefaultValue<T>(string parameterName, T argument) where T : struct
        {
            var value = default(T);

            if (argument.Equals(value))
            {
                throw new DefaultValueException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "Argument {0} is equal to its default value {1}.",
                        parameterName,
                        value
                    )
                );
            }
        }

        [DebuggerStepThrough]
        public static void AgainstDefaultValues<T>(string parameterName, IEnumerable<T> argument) where T : struct
        {
            var value = default(T);

            if (argument.Contains(value))
            {
                throw new DefaultValueException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "Argument {0} contains an element equal to its default value {1}.",
                        parameterName,
                        value
                    )
                );
            }
        }

        /// <summary>
        /// Determines whether the specified type is a nullable type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        /// <c>true</c> if the specified type is a nullable type; otherwise, <c>false</c>.
        /// </returns>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Source package.")]
        private static bool IsNullableType(this Type type)
        {
            return !type.IsValueType || type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        public class EmptyStringException : Exception
        {
            public EmptyStringException(string message) : base(message)
            {
            }
        }

        public class WhitespaceException : Exception
        {
            public WhitespaceException(string message) : base(message)
            {
            }
        }

        public class StringExceedsNCharactersException : Exception
        {
            public StringExceedsNCharactersException(string message) : base(message)
            {
            }
        }

        public class EmptyGuidException : Exception
        {
            public EmptyGuidException(string message) : base(message)
            {
            }
        }

        public class DefaultValueException : Exception
        {
            public DefaultValueException(string message) : base(message)
            {
            }
        }

        public class EmptyListException : Exception
        {
            public EmptyListException(string message) : base(message)
            {
            }
        }
    }
}