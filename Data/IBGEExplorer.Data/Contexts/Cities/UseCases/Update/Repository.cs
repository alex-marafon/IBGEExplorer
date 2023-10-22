using IBGEExplorer.Cities.Entities;
using IBGEExplorer.Cities.UseCases.Update.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IBGEExplorer.Data.Contexts.Cities.UseCases.Update;

public class Repository : IRepository
{
    private readonly DataContext _context;

    public Repository(DataContext context) =>
        _context = context;

    public Task<IBGE?> GetOneByIBGECodeUpateAsync(string IBGECode) =>
        _context.City
        .FirstOrDefaultAsync(x => x.IBGECode == IBGECode);

    public async Task UpateAsync(IBGE city)
    {
        _context.Entry(city).State = EntityState.Modified;
        await SaveAsync();
    }

    private Task SaveAsync() =>
        _context.SaveChangesAsync();
}