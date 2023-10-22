using IBGEExplorer.Cities.UseCases.State.Get.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IBGEExplorer.Data.Contexts.State.UseCases.Get;

public class Repository : IRepository
{
    private readonly DataContext _context;

    public Repository(DataContext context) =>
        _context = context;

    public async Task<IBGEExplorer.Cities.Entities.State?> GetOneByCodeAsync(string code) =>
        await _context.State
        .FirstOrDefaultAsync(x => x.Code == code);

    public async Task<IBGEExplorer.Cities.Entities.State?> GetOneByCodeAsnoTrackingAsync(string code) =>
        await _context.State
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.Code == code);

    public async Task<IBGEExplorer.Cities.Entities.State?> GetOneByIdAsync(int id)
    {
        return await _context.State
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<IBGEExplorer.Cities.Entities.State>?> GetAllAsync() =>
        await _context.State
        .ToListAsync();
}