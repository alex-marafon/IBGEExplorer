using IBGEExplorer.Cities.UseCases.State.Create.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IBGEExplorer.Data.Contexts.State.UseCases.Create;

public class Repository : IRepository
{
    private readonly DataContext _context;

    public Repository(DataContext context) =>
        _context = context;

    public async Task CreateAsync(IBGEExplorer.Cities.Entities.State state)
    {
        await _context.State.AddAsync(state);
        await SaveChangesAsync();
    }

    public async Task<bool> IsAlreadyRegisteredStateAsync(string code) =>
        await _context.State
        .AnyAsync(x => x.Code == code);

    private async Task SaveChangesAsync() =>
        await _context.SaveChangesAsync();
}
