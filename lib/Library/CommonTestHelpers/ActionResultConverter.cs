namespace Library.CommonTestHelpers
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The action result converter.
    /// </summary>
    public static class ActionResultConverter
    {
        /// <summary>
        /// Converts an <see cref="IActionResult"/> to the given type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The result actual result type.</typeparam>
        /// <param name="response">The response to convert.</param>
        /// <returns>The response as <typeparamref name="T"/>.</returns>
        public static T Convert<T>(this IActionResult response)
        {
            return (T)((ObjectResult)response).Value;
        }
    }
}