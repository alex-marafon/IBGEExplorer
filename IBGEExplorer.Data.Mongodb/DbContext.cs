using MongoDB.Driver;

namespace IBGEExplorer.Data.Mongodb;
public class DbContext : IDatabaseContext
{
    private MongoClient dbmsClient;
    public IMongoDatabase Database { get; set; }

    public string NameBanco = "Nome do Banco";
    public DbContext()
    {
        dbmsClient = new MongoClient(GetDatabaseConnectionString());
        Database = dbmsClient.GetDatabase(NameBanco);
    }

    public string GetDatabaseConnectionString()
    {
        string response;
        var servername = Environment.GetEnvironmentVariable("SERVERNAME");
        switch (servername)
        {
            case "SANDBOX":
                response = "Connection String";
                break;
            case "DEV":
                response = "Connection String";
                break;
            default:
                response = "Connection String";
                break;
        }

        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
        Console.WriteLine($"\n SERVERNAME: {servername} \n");
        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
        return response;
    }

    public IMongoCollection<T> GetCollection<T>()
    {
        return Database.GetCollection<T>(typeof(T).Name);
    }
}