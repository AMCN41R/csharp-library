namespace Library.Mongo.Exceptions
{
    using System;

    /// <summary>
    /// The exception that is thrown by the <see cref="IMongoDatabaseFactory"/>
    /// </summary>
    public class MongoDatabaseFactoryException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDatabaseFactoryException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public MongoDatabaseFactoryException(string message)
            : base(message)
        {
        }
    }
}