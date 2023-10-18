using IBGEExplorer.Shared.Services.Contracts;
using RestSharp;

namespace IBGEExplorer.Shared.Services;

public class LogService : ILoggerService
{
    public async Task LogAsync(string message, string key = "", string data = "")
    {
        object body = new
        {
            username = "IBGE Explorer",
            avatar_url = "",
            content = $"{message} {key} \n {data}"
        };

        RestRequest req = new RestRequest()
            .AddJsonBody(body);

        await SendAsync(req);
    }

    private async Task SendAsync(RestRequest req)
    {
        RestClient client = new(Configuration.Discord.LogUrl);
        await client.PostAsync(req);
    }
}