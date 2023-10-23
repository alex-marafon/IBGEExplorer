using IBGEExplorer.Cities.Entities;

namespace IBGEExplorer.Cities.UseCases.Import.Contracts;
public interface IRepository
{
    Task SaveListCityAsync(IEnumerable<City> city);
    Task SaveCityAsync(City city);
    Task<bool> CodeIbgeExist(string codeIbge);

}