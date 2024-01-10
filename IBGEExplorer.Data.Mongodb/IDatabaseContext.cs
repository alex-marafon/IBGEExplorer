using MongoDB.Driver;

namespace IBGEExplorer.Data.Mongodb;
public interface IDatabaseContext
{
    IMongoDatabase Database { get; set; }
    IMongoCollection<T> GetCollection<T>();
}
