using IBGEExplorer.Cities.Entities;

namespace IBGEExplorer.Cities.UseCases.IBGE.Create.Contracts;

public interface IRepository
{
    public Task CreateAsync(Entities.IBGE city);
    public Task<bool> IsAlreadyRegisteredAccountAsync(string IBGECode);
}