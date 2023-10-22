using IBGEExplorer.Account.Entities;
using Microsoft.EntityFrameworkCore;
using IBGEExplorer.Account.UseCases.Role.Get.Contracts;

namespace IBGEExplorer.Data.Contexts.Roles.UsesCases.Get;

public class Repository : IRepository
{
    private readonly DataContext _context;

    public Repository(DataContext context) =>
        _context = context;

    public async Task<Role?> GetOneById(int id) =>
        await _context.Role.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Role?> GetOneByIdAsNoTracking(int id) =>
        await _context.Role
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.Id == id);

    public IQueryable<Role> GetByIdListAsNoTracking() =>
        _context.Role
        .AsNoTracking()
        .AsQueryable();

    private void SaveAsync() =>
        _context.SaveChanges();
}