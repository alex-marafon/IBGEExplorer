namespace IBGEExplorer.Account.UseCases.UserRole.Create.Contracts;

public interface IRepository
{
    public Task CreateAsync(Entities.UserRole userRole);
}