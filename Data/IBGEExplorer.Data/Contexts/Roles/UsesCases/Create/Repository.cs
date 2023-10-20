using IBGEExplorer.Account.Entities;
using IBGEExplorer.Account.UseCases.Role.Create.Contracts;

namespace IBGEExplorer.Data.Contexts.Roles.UsesCases.Create;

public class Repository : IRepository
{
    private readonly DataContext _context;

    public Repository(DataContext context) =>
        _context = context;

    public async Task CreateAsync(Role user)
    {
        await _context.AddAsync(user);
        await SaveAsync();
    }

    private async Task SaveAsync() =>
        await _context.SaveChangesAsync();
}