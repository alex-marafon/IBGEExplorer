using IBGEExplorer.Account.UseCases.UserRole.Create.Contracts;

namespace IBGEExplorer.Data.Contexts.UserRole.UsesCases.Create;

public class Repository : IRepository
{
    private readonly DataContext _context;

    public Repository(DataContext context) =>
        _context = context;

    public async Task CreateAsync(IBGEExplorer.Account.Entities.UserRole userRole)
    {
        await _context.UserRole.AddAsync(userRole);
        await SaveAsync();
    }

    private async Task SaveAsync() =>
        await _context.SaveChangesAsync();
}