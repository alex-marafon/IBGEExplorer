using IBGEExplorer.Cities.UseCases.County.Create.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IBGEExplorer.Data.Contexts.County.UseCases.Create;

public class Repository : IRepository
{
    private DataContext _context;

    public Repository(DataContext context) =>
        _context = context;

    public async Task CreateAsync(IBGEExplorer.Cities.Entities.County county)
    {
        await _context.County.AddAsync(county);
        await SaveAsync();
    }

    public async Task<bool> IsAlreadyRegisteredCountyAsync(string code) =>
        await _context.County
            .AnyAsync(x => x.Code == code);

    private async Task SaveAsync() =>
        await _context.SaveChangesAsync();
}