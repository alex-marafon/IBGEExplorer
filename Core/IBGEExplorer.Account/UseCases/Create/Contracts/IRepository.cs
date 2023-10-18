using IBGEExplorer.Account.Entities;

namespace IBGEExplorer.Account.UseCases.Create.Contracts;

public interface IRepository
{
    Task<bool> IsAlreadyRegisteredAccountAsync(string emailAddress);

    Task SaveAsync(User user);
}