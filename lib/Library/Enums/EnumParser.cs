namespace Library.Enums
{
    using System;

    using Library.Guards;

    /// <summary>
    /// Helper functions to parse enum values.
    /// </summary>
    public class EnumParser
    {
        /// <summary>
        /// Converts a string to the corresponding enum value.
        /// </summary>
        /// <typeparam name="T">The enum type.</typeparam>
        /// <param name="value">The value to convert.</param>
        /// <returns>The enum value.</returns>
        /// <remarks>
        /// This is a case sensitive conversion.
        /// </remarks>
        public static T Parse<T>(string value)
            where T : struct, IConvertible
        {
            Guard.AgainstNullOrWhitespaceArgument(nameof(value), value);

            return Parse<T>(value, false);
        }

        /// <summary>
        /// Converts a string to the corresponding enum value.
        /// </summary>
        /// <typeparam name="T">The enum type.</typeparam>
        /// <param name="value">The value to convert.</param>
        /// <param name="ignoreCase">true to ignore case; false to regard case.</param>
        /// <returns>The enum value.</returns>
        public static T Parse<T>(string value, bool ignoreCase)
            where T : struct, IConvertible
        {
            Guard.AgainstNullOrWhitespaceArgument(nameof(value), value);

            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be enum");
            }

            return (T)Enum.Parse(typeof(T), value, ignoreCase);
        }
    }
}
