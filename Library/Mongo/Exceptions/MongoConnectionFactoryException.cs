namespace Library.Mongo.Exceptions
{
    using System;

    /// <summary>
    /// The exception that is thrown by the <see cref="MongoConnectionFactory"/>.
    /// </summary>
    public class MongoConnectionFactoryException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MongoConnectionFactoryException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public MongoConnectionFactoryException(string message)
            : base(message)
        {
        }
    }
}