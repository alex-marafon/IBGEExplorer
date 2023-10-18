namespace IBGEExplorer.Shared.Services.Contracts;

public interface ILoggerService
{
    Task LogAsync(string message, string key = "", string data = "");
}