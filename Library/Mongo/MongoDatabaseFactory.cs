using Library.Mongo.Exceptions;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Library.Mongo
{
    public class MongoDatabaseFactory : IMongoDatabaseFactory
    {
        private const string DbConfigKey = "";

        public MongoDatabaseFactory(IMongoConnectionFactory factory, IConfiguration config)
        {
            this.Client = factory.GetClient();
            var dbName = config[DbConfigKey];

            if (string.IsNullOrWhiteSpace(dbName))
            {
                throw new MongoCollectionFactoryException(
                    "Cannot find database name in configuration file.");
            }

            this.DatabaseName = dbName;
        }

        private IMongoClient Client { get; }

        private string DatabaseName { get; }

        public IMongoDatabase GetDatabase()
        {
            return this.Client.GetDatabase(this.DatabaseName);
        }
    }
}