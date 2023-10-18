using IBGEExplorer.Account.Entities;
using IBGEExplorer.Account.UseCases.Create.Contracts;

namespace IBGEExplorer.Data.Contexts.Account.UseCases.Create;

public class Repository : IRepository
{
    public async Task<bool> IsAlreadyRegisteredAccountAsync(string emailAddress)
    {
        throw new NotImplementedException();
    }

    public async Task SaveAsync(User user)
    {
        throw new NotImplementedException();
    }
}