using IBGEExplorer.Core.Contexts.Account.Entities;
using SharedContext.Services.Log.Contracts;
using System.Text.Json;
using SharedContext.Extensions;

namespace IBGEExplorer.Core.Contexts.Account.Create;

public class Handler
{
    private readonly ILoggerService _logger;

    public Handler(ILoggerService log) => _logger = log;    

    public async Task<string> CreateAccountAsync(Request account)
    {
        User user = new User
        {
            Id = Guid.NewGuid(),
            Email = account.Email,
            Password = StringEstensions.ToSha256(account.Password),
            FullName =
            {
                FirstName = "Nome",
                LastName = "Sobre Nome"
            }
        };

        user.ChangeUserName(new (name));

        var json = JsonSerializer.Serialize(user);
        await _logger.LogAsync("Erro ao criar usuário", "c9933e53", json);
                
        return "contas criadas"; 
    }
}