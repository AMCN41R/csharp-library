namespace Library.Mongo
{
    using MongoDB.Driver;

    public interface IMongoDatabaseFactory
    {
        IMongoDatabase GetDatabase();
    }
}