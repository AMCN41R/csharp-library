namespace Library.Mongo
{
    using MongoDB.Driver;

    public interface IMongoConnectionFactory
    {
        IMongoClient GetClient();
    }
}
