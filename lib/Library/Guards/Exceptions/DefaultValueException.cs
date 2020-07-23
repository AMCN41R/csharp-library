namespace Library.Guards.Exceptions
{
    using System;

    /// <summary>
    /// The exception that is thrown when a value is equal to the default value for it's type.
    /// </summary>
    public class DefaultValueException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultValueException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public DefaultValueException(string message)
            : base(message)
        {
        }
    }
}
