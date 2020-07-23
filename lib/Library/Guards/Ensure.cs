namespace Library.Guards
{
    using System;

    using Library.Guards.Exceptions;

    /// <summary>
    /// Provides guard clauses.
    /// </summary>
    public static class Ensure
    {
        /// <summary>
        /// Throws an exception if an argument is null, otherwise returns the argument.
        /// </summary>
        /// <typeparam name="TArgument">The type of the argument.</typeparam>
        /// <param name="argument">The argument.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <returns>The argument if it is not null.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument" /> is <c>null</c>.</exception>
        /// <remarks>
        /// <typeparamref name="TArgument" /> is restricted to reference types to avoid boxing of value type objects.
        /// </remarks>
        public static TArgument NotNull<TArgument>([ValidatedNotNull][NoEnumeration] TArgument argument, string parameterName)
            where TArgument : class
        {
            if (argument == null)
            {
                throw new ArgumentNullException(
                    parameterName,
                    $"{parameterName} is null"
                );
            }

            return argument;
        }

        /// <summary>
        /// Throws an exception if a string is null or empty, otherwise returns the string.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <returns>The argument if it is not null or empty.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument" /> is <c>null</c> or <see cref="string.Empty"/>.</exception>
        public static string NotNullOrEmpty([ValidatedNotNull] string argument, string parameterName)
        {
            if (string.IsNullOrEmpty(argument))
            {
                var value = argument == null ? "null" : "empty";

                throw new ArgumentNullException(
                    parameterName,
                    $"{parameterName} is {value}"
                );
            }

            return argument;
        }

        /// <summary>
        /// Throws an exception if a string is null, empty or whitespace,
        /// otherwise returns the string.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <returns>The argument if it is not null, empty or whitespace.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="argument" /> is <c>null</c>, whitespace or <see cref="string.Empty"/>.</exception>
        public static string NotNullOrWhitespace([ValidatedNotNull] string argument, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(argument))
            {
                var value =
                    argument == null
                        ? "null"
                        : argument == string.Empty ? "empty" : "whitespace";

                throw new ArgumentNullException(
                    parameterName,
                    $"{parameterName} is {value}"
                );
            }

            return argument;
        }

        /// <summary>
        /// Throws an exception if an argument is less than zero, otherwise
        /// returns the argument.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <returns>The argument if it is not less than zero.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> is less than zero.</exception>
        public static decimal NotNegative(decimal argument, string parameterName)
        {
            if (argument < 0)
            {
                throw new ArgumentOutOfRangeException(
                    parameterName,
                    argument,
                    $"{parameterName} cannot be less than zero."
                );
            }

            return argument;
        }

        /// <summary>
        /// Throws an exception if an argument is less than zero, otherwise
        /// returns the argument.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <returns>The argument if it is not less than zero.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="argument"/> is less than zero.</exception>
        public static int NotNegative(int argument, string parameterName)
        {
            if (argument < 0)
            {
                throw new ArgumentOutOfRangeException(
                    parameterName,
                    argument,
                    $"{parameterName} cannot be less than zero."
                );
            }

            return argument;
        }

        /// <summary>
        /// Throws an exception if an argument is equal to its default value,
        /// otherwise returns the argument.
        /// </summary>
        /// <typeparam name="TArgument">The argument type.</typeparam>
        /// <param name="argument">The argument</param>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>The argument if it is not equal to its default value.</returns>
        /// <exception cref="DefaultValueException">Thrown when <paramref name="argument"/> is equal to its default value.</exception>
        public static TArgument NotDefault<TArgument>(TArgument argument, string parameterName)
            where TArgument : struct
        {
            var value = default(TArgument);

            if (argument.Equals(value))
            {
                throw new DefaultValueException(
                    $"Argument {parameterName} cannot be equal to its default value {value}."
                );
            }

            return argument;
        }
    }
}
