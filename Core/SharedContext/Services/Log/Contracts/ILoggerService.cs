namespace SharedContext.Services.Log.Contracts;

public interface ILoggerService
{
    Task LogAsync(string message, string key = "", string data = "");
}
