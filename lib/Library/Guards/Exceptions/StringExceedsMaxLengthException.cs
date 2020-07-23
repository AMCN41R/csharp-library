namespace Library.Guards.Exceptions
{
    using System;

    /// <summary>
    /// The exception that is thrown when a string exceeds its maximum length.
    /// </summary>
    public class StringExceedsMaxLengthException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringExceedsMaxLengthException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public StringExceedsMaxLengthException(string message)
            : base(message)
        {
        }
    }
}
