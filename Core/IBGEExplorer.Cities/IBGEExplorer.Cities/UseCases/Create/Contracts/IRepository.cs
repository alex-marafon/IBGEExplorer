using IBGEExplorer.Cities.Entities;

namespace IBGEExplorer.Cities.UseCases.Create.Contracts;

public interface IRepository
{
    public Task CreateAsync(City city);
    public Task<bool> IsAlreadyRegisteredAccountAsync(string IBGECode);
}