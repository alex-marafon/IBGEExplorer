using IBGEExplorer.Cities.Entities;

namespace IBGEExplorer.Cities.UseCases.Update.Contracts;

public interface IRepository
{
    public Task UpateAsync(Entities.IBGE city);
    public Task<Entities.IBGE> GetOneByIBGECodeUpateAsync(string IBGECode);
}