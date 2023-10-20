using IBGEExplorer.Account.Entities;
using Microsoft.EntityFrameworkCore;

namespace IBGEExplorer.Data.Contexts.Roles.Create;

public class Repository
{
    private readonly DataContext _context;

    public Repository(DataContext context) =>
        _context = context;

    public async Task SaveAsync(Role user)
    {
        await _context.AddAsync(user);
        SaveAsync();
    }
    public async Task<Role?> GetOneById(int id) =>
        await _context.Role.FirstOrDefaultAsync(x => x.Id == id);
    public async Task<Role?> GetOneByIdAsNoTracking(int id) =>
        await _context.Role
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.Id == id);

    public IQueryable<Role>? GetByIdListAsNoTracking(List<int> id) =>
        _context.Role
        .AsNoTracking()
        .AsQueryable();

    private void SaveAsync() =>
        _context.SaveChanges();
}