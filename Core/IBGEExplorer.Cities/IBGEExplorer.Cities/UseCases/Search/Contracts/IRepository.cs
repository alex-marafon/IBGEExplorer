using IBGEExplorer.Cities.Entities;

namespace IBGEExplorer.Cities.UseCases.Search.Contracts;
public interface IRepository
{
    Task<City?> GetCityByCode(string code);
    Task<City?> GetCityByCodeAsNoTracking(string code);
    Task<List<City>?> GetCityByStateAsNoTracking(string stateName);
    Task<List<City>?> GetByCityNameAsNoTracking(string cityName);   
}