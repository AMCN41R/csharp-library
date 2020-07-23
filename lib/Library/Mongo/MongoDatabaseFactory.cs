namespace Library.Mongo
{
    using Library.Mongo.Exceptions;

    using Microsoft.Extensions.Configuration;

    using MongoDB.Driver;

    /// <inheritdoc />
    public class MongoDatabaseFactory : IMongoDatabaseFactory
    {
        private const string DbConfigKey = "";

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDatabaseFactory"/> class.
        /// </summary>
        /// <param name="factory">The mongo connection factory.</param>
        /// <param name="config">The configuration object</param>
        public MongoDatabaseFactory(IMongoConnectionFactory factory, IConfiguration config)
        {
            this.Client = factory.GetClient();
            var dbName = config[DbConfigKey];

            if (string.IsNullOrWhiteSpace(dbName))
            {
                throw new MongoDatabaseFactoryException(
                    "Cannot find database name in configuration file."
                );
            }

            this.DatabaseName = dbName;
        }

        private IMongoClient Client { get; }

        private string DatabaseName { get; }

        /// <inheritdoc />
        public IMongoDatabase GetDatabase()
        {
            return this.Client.GetDatabase(this.DatabaseName);
        }
    }
}