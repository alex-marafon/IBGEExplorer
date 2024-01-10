using IBGEExplorer.Account.UseCases.Create.Contracts;
using MongoDB.Driver;

namespace IBGEExplorer.Data.Mongodb.Context.User.UseCases.Create;
public class Repository : IRepository
{
    protected IDatabaseContext Db;

    public Repository(IDatabaseContext db) => Db = db;

    public Task<bool> IsAlreadyRegisteredAccountAsync(string emailAddress)
    {
        var collection = Db.GetCollection<Mapping.User.User>();
        var filter = Builders<Mapping.User.User>.Filter.Where(x => x.Email.Equals(emailAddress));
        var result = collection.Find(filter).FirstOrDefaultAsync();
        return Task.FromResult(result != null);
    }

    public Task Create(Account.Entities.User user)
    {
        var userMap = Mapping.User.User.MapperUserDb(user) ?? throw new ArgumentNullException("Mapping.User.User.MapperUserDb(user)");

        Db.GetCollection<Mapping.User.User>().InsertOne(userMap);
        return Task.CompletedTask;
    }
}