using IBGEExplorer.Account.Entities;
using IBGEExplorer.Account.UseCases.Get.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IBGEExplorer.Data.Contexts.Account.UseCases.Get;

public class Repository : IRepository
{
    private readonly DataContext _context;

    public Repository(DataContext context) =>
        _context = context;
    
    public async Task<User?> GetUserById(int id) =>
        await _context.User
        .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<User?> GetUserByIdAsNoTracking(int id) =>
        await _context.User
            .AsNoTracking()
            .Include(user => user.UserRoles!)
                .ThenInclude(role => role.Role!)
            .FirstOrDefaultAsync(x => x.Id == id);  

    public async Task<User?> GetUserByEmailAsNoTracking(string email) =>
        await _context.User
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email == email);
}