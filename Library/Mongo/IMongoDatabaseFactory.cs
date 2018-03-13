using MongoDB.Driver;

namespace Library.Mongo
{
    public interface IMongoDatabaseFactory
    {
        IMongoDatabase GetDatabase();
    }
}