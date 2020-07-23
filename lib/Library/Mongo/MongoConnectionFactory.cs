namespace Library.Mongo
{
    using Library.Mongo.Exceptions;

    using Microsoft.Extensions.Configuration;

    using MongoDB.Bson.Serialization.Conventions;
    using MongoDB.Driver;

    /// <inheritdoc />
    /// <remarks>
    /// During construction, registers the Mongo 'camelCaseConvention' for all
    /// types whose namespace starts with the namespace root specified by the
    /// <see cref="AppNamespaceRoot"/> property.
    /// </remarks>
    public class MongoConnectionFactory : IMongoConnectionFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MongoConnectionFactory"/> class.
        /// </summary>
        /// <param name="config">The configuration object.</param>
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
                t => t.FullName?.StartsWith(this.AppNamespaceRoot) == true
            );
        }

        private IMongoClient Client { get; }

        // [ SET THIS ] //
        private string AppNamespaceRoot => string.Empty;

        // [ SET THIS ] //
        private string DbConnectionKey => string.Empty;

        /// <inheritdoc />
        public IMongoClient GetClient()
        {
            return this.Client;
        }
    }
}
