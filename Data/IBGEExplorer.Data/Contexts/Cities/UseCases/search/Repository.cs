using IBGEExplorer.Cities.Entities;
using IBGEExplorer.Cities.UseCases.Search.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IBGEExplorer.Data.Contexts.Cities.UseCases.Search;

public class Repository : IRepository
{
    private readonly DataContext _context;

    public Repository(DataContext context) =>
        _context = context;

    public Task<City?> GetCityByCode(string code) =>
        _context.City
        .FirstOrDefaultAsync(x => x.IBGECode == code);

    public Task<City?> GetCityByCodeAsNoTracking(string code) =>
        _context.City
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.IBGECode == code);

    public Task<City?> GetCityById(int id) =>
        _context.City
        .FirstOrDefaultAsync(x => x.Id == id);

    public Task<City?> GetCityByIdAsNoTracking(int id) =>
        _context.City
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.Id == id);
}
