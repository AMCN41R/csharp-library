namespace Library.Guards.Exceptions
{
    using System;

    /// <summary>
    /// The exception that is thrown when a list is empty.
    /// </summary>
    public class EmptyListException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmptyListException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public EmptyListException(string message)
            : base(message)
        {
        }
    }
}
