namespace IBGEExplorer.Cities.UseCases.County.Create.Contracts;
public interface IRepository
{
    Task CreateAsync(Entities.County county);
    Task<bool> IsAlreadyRegisteredCountyAsync(string code);
}
