using MongoDB.Driver;

namespace Library.Mongo
{
    public interface IMongoConnectionFactory
    {
        IMongoClient GetClient();
    }
}
