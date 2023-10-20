using IBGEExplorer.Account.Entities;
using IBGEExplorer.Account.UseCases.Create.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IBGEExplorer.Data.Contexts.Account.UseCases.Create;

public class Repository : IRepository
{
    private readonly DataContext _context;

    public Repository(DataContext context) =>
        _context = context;   

    public async Task<bool> IsAlreadyRegisteredAccountAsync(string emailAddress) => 
        await _context.User.AnyAsync(x => x.Email == emailAddress);

    public async Task SaveAsync(User user)
    {
        await _context.AddAsync(user);
        SaveAsync();
    }

    private void SaveAsync() =>
        _context.SaveChanges(); 
}