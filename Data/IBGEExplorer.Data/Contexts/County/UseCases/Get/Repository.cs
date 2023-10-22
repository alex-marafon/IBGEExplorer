using IBGEExplorer.Cities.UseCases.County.Get.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IBGEExplorer.Data.Contexts.County.UseCases.Get;

public class Repository : IRepository
{
    private DataContext _context;

    public Repository(DataContext context) =>
        _context = context;

    public async Task<List<IBGEExplorer.Cities.Entities.County>?> GetAllAsync() =>
        await _context.County
        .Include(x => x.State)
        .ToListAsync();

    public async Task<IBGEExplorer.Cities.Entities.County?> GetOneByCode(string code) =>
        await _context.County
        .FirstOrDefaultAsync(x => x.Code == code);

    public async Task<IBGEExplorer.Cities.Entities.County?> GetOneByCodeAsNoTrackingAsync(string code) =>
        await _context.County
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.Code == code);
}