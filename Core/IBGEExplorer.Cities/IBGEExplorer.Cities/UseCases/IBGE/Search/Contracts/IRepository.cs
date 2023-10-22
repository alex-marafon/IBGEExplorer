using IBGEExplorer.Cities.Entities;

namespace IBGEExplorer.Cities.UseCases.IBGE.Search.Contracts;
public interface IRepository
{
    Task<Entities.IBGE?> GetCityByCode(string code);
    Task<Entities.IBGE?> GetCityByCodeAsNoTracking(string code);
    Task<List<Entities.IBGE>?> GetCityByStateAsNoTracking(string stateName);
    Task<List<Entities.IBGE>?> GetByCityNameAsNoTracking(string cityName);
}