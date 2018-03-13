using System;

namespace Library.Mongo.Exceptions
{
    public class MongoCollectionFactoryException : Exception
    {
        public MongoCollectionFactoryException(string message) : base(message)
        {
        }
    }
}