using IBGEExplorer.Cities.Entities;

namespace IBGEExplorer.Cities.UseCases.IBGE.Import.Contracts;
public interface IRepository
{
    Task SaveListCityAsync(IEnumerable<Entities.IBGE> city);
    Task SaveCityAsync(Entities.IBGE city);

}