using IBGEExplorer.Cities.Entities;
using IBGEExplorer.Cities.UseCases.Create.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IBGEExplorer.Data.Contexts.Cities.UseCases.Create;

public class Repository : IRepository
{
    private readonly DataContext _context;

    public Repository(DataContext context) =>
        _context = context;

    public async Task<bool> IsAlreadyRegisteredAccountAsync(string IBGECode) =>
        await _context.City.AnyAsync(x => x.IBGECode == IBGECode);
    public async Task CreateAsync(City city)
    {
        await _context.City.AddAsync(city);
        await SaveAsync();
    }

    private async Task SaveAsync() =>
        await _context.SaveChangesAsync();
}