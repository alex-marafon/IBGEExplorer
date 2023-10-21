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

    public Task<List<City>?> GetCityByStateAsNoTracking(string stateName) =>
        _context.City
        .AsNoTracking()
        .Where(x => x.StateName == stateName)
        .ToListAsync()!;

    public Task<List<City>?> GetByCityNameAsNoTracking(string cityName) =>
        _context.City
        .AsNoTracking()
        .Where(x => x.CityName == cityName)
        .ToListAsync()!;
}
