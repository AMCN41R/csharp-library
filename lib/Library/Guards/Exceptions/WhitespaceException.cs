namespace Library.Guards.Exceptions
{
    using System;

    /// <summary>
    /// The exception that is thrown when a string is only whitespace characters.
    /// </summary>
    public class WhitespaceException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhitespaceException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public WhitespaceException(string message)
            : base(message)
        {
        }
    }
}
