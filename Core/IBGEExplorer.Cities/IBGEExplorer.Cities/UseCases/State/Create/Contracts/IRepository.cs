namespace IBGEExplorer.Cities.UseCases.State.Create.Contracts;

public interface IRepository
{
    Task CreateAsync(Entities.State state);
    Task<bool> IsAlreadyRegisteredStateAsync(string code);
}