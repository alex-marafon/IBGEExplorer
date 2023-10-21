using IBGEExplorer.Cities.Entities;
using IBGEExplorer.Cities.UseCases.Import.Contracts;

namespace IBGEExplorer.Data.Contexts.Cities.UseCases.Import;
public class Repository : IRepository
{
    private readonly DataContext _context;

    public Repository(DataContext context) =>
        _context = context;


    public async Task SaveListCityAsync(IEnumerable<City> city)
    {
        await _context.AddRangeAsync(city);
        SaveAsync();
    }


    public async Task SaveCityAsync(City city)
    {
        await _context.AddAsync(city);
        SaveAsync();
    }


    private void SaveAsync() =>
        _context.SaveChanges();
  
}