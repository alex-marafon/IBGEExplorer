using IBGEExplorer.Cities.Entities;

namespace IBGEExplorer.Cities.UseCases.Update.Contracts;

public interface IRepository
{
    public Task UpateAsync(City city);
    public Task<City> GetOneByIBGECodeUpateAsync(string IBGECode);
}