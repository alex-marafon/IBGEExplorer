using IBGEExplorer.Cities.Entities;
using IBGEExplorer.Cities.UseCases.Import.Contracts;
using Microsoft.EntityFrameworkCore;

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

    public async Task<bool> CodeIbgeExist(string codeIbge)
    {
          var codeExist =   _context.City.FirstOrDefaultAsync(x => x.IBGECode == codeIbge);
          return codeExist != null;
    }

private void SaveAsync() =>
        _context.SaveChanges();
  
}