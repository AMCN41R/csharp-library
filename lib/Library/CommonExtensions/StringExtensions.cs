﻿namespace Library.CommonExtensions
{
    /// <summary>
    /// A set of extension methods on <see cref="string"/>.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Indicates whether the specified string is empty.
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns>true if the <paramref name="value">value</paramref> parameter is an empty string (""); otherwise, false.</returns>
        public static bool IsEmpty(this string value)
        {
            return value == string.Empty;
        }

        /// <summary>
        /// Indicates whether the specified string is null or empty.
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns>true if the <paramref name="value">value</paramref> parameter is null or an empty string (""); otherwise, false.</returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Indicates whether the specified string is null, empty, or consists only of white-space characters.
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns>true if the <paramref name="value">value</paramref> parameter is null or <see cref="string.Empty"></see>, or if <paramref name="value">value</paramref> consists exclusively of white-space characters.</returns>
        public static bool IsNullOrWhitespace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
    }
}
