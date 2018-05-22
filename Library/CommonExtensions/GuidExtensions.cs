namespace Library.CommonExtensions
{
    using System;

    using Library.Guards;

    /// <summary>
    /// A set of extensions for converting values to and from <see cref="Guid"/>.
    /// </summary>
    public static class GuidExtensions
    {
        /// <summary>
        /// Converts a string to a <see cref="Guid"/>.
        /// </summary>
        /// <param name="guid">The string to convert.</param>
        /// <returns>A <see cref="Guid"/>.</returns>
        /// <remarks>
        /// This is just a wrapper for <see cref="Guid.Parse(string)"/>.
        /// </remarks>
        public static Guid ToGuid(this string guid)
        {
            Guard.AgainstNullOrWhitespaceArgument(nameof(guid), guid);

            return Guid.Parse(guid);
        }

        /// <summary>
        /// Converts a base64 encoded guid back to its original form.
        /// </summary>
        /// <param name="base64String">The encoded string.</param>
        /// <returns>The original guid.</returns>
        public static Guid ToGuidFromBase64String(this string base64String)
        {
            Guard.AgainstNullOrWhitespaceArgument(nameof(base64String), base64String);

            return new Guid(Convert.FromBase64String(base64String));
        }

        /// <summary>
        /// COnverts a guid into a base64 encoded string.
        /// </summary>
        /// <param name="guid">The guid to convert.</param>
        /// <returns>The guid as a base64 encoded string.</returns>
        public static string ToBase64String(this Guid guid)
        {
            return Convert.ToBase64String(guid.ToByteArray());
        }
    }
}
