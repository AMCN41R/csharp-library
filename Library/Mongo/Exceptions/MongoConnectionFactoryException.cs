using System;

namespace Library.Mongo.Exceptions
{
    public class MongoConnectionFactoryException : Exception
    {
        public MongoConnectionFactoryException(string message) : base(message)
        {
        }
    }
}