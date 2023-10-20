using IBGEExplorer.Cities.Entities;

namespace IBGEExplorer.Cities.UseCases.Import.Contracts;
public interface IRepository
{
    Task<City?> SaveCityAsync(City city);

}