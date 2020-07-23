namespace Library.Guards.Exceptions
{
    using System;

    /// <summary>
    /// The exception that is thrown when a string is empty.
    /// </summary>
    public class EmptyStringException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmptyStringException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public EmptyStringException(string message)
            : base(message)
        {
        }
    }
}
