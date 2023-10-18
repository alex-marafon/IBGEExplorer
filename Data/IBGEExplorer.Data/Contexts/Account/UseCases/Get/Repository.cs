using IBGEExplorer.Account.Entities;
using IBGEExplorer.Account.UseCases.Get.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IBGEExplorer.Data.Contexts.Account.UseCases.Get;

//usar context
public class Repository : IRepository
{
    private readonly DataContext _context;

    public Repository(DataContext context) =>
        _context = context;
    

    public async Task<User?> GetUser(int id)
    {
        var user = await _context.User.FirstOrDefaultAsync(x => x.Id == id);  
        return user;
    }

    public async Task<User?> GetUser(string email)
    {
        var user = await _context.User.FirstOrDefaultAsync(x => x.Email == email);
        return user;
    }
}