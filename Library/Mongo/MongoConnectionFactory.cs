using Library.Mongo.Exceptions;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Library.Mongo
{
    public class MongoConnectionFactory : IMongoConnectionFactory
    {
        private string AppNamespaceRoot => "";
        private string DbConnectionKey => "";

        public MongoConnectionFactory(IConfiguration config)
        {
            var connString = config.GetConnectionString(this.DbConnectionKey);

            if (string.IsNullOrWhiteSpace(connString))
            {
                throw new MongoConnectionFactoryException(
                    "Cannot find database connection string in configuration file.");
            }

            this.Client = new MongoClient(connString);

            ConventionRegistry.Register(
                "camelCaseConvention",
                new ConventionPack { new CamelCaseElementNameConvention() },
                t => t.FullName?.StartsWith(this.AppNamespaceRoot) == true);
        }

        private IMongoClient Client { get; }

        public IMongoClient GetClient()
        {
            return this.Client;
        }
    }
}
