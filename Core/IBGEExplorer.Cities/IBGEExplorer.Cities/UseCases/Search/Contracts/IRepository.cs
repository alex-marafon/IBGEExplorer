
using IBGEExplorer.Cities.Entities;

namespace IBGEExplorer.Cities.UseCases.Search.Contracts;
public interface IRepository
{
    Task<City?> GetCityById(int id);
    Task<City?> GetCityByIdAsNoTracking(int id);
    Task<City?> GetCityByCode(string code);
    Task<City?> GetCityByCodeAsNoTracking(string code);

}
