using IBGEExplorer.Cities.Entities;
using IBGEExplorer.Cities.UseCases.IBGE.Search.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IBGEExplorer.Data.Contexts.Cities.UseCases.Search;

public class Repository : IRepository
{
    private readonly DataContext _context;

    public Repository(DataContext context) =>
        _context = context;

    public Task<IBGE?> GetCityByCode(string code) =>
        _context.City
        .FirstOrDefaultAsync(x => x.IBGECode == code);

    public Task<IBGE?> GetCityByCodeAsNoTracking(string code) =>
        _context.City
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.IBGECode == code);

    public Task<List<IBGE>?> GetCityByStateAsNoTracking(string stateName) =>
        _context.City
        .AsNoTracking()
        .Where(x => x.County.Name == stateName)
        .ToListAsync()!;

    public Task<List<IBGE>?> GetByCityNameAsNoTracking(string cityName) =>
        _context.City
        .AsNoTracking()
        .Where(x => x.County.Name == cityName)
        .ToListAsync()!;
}
