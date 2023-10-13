using SharedContext.Services.Log.Contracts;
using System.Text.Json;

namespace IBGEExplorer.Core.Contexts.Account.Create;

public class Handler
{
    private readonly ILoggerService _logger;

    public Handler(ILoggerService log) => _logger = log;    

    public async Task<string> CreateAccountAsync(string email, string password)
    {
        var user = new
        {
            email = email,
            password = password
        };

        var json = JsonSerializer.Serialize(user);
        await _logger.LogAsync("Erro ao criar usuário", "c9933e53", json);
                
        return "contas criadas"; 
    }
}