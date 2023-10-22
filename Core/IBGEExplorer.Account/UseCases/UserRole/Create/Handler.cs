using IBGEExplorer.Account.Entities;
using IBGEExplorer.Account.UseCases.UserRole.Create.Contracts;

namespace IBGEExplorer.Account.UseCases.UserRole.Create;

public class Handler
{
    private readonly IRepository _repository;

    public Handler(IRepository repository) =>
        _repository = repository;

    public async Task CreateAsync(User user, List<Entities.Role> roles)
    {
        foreach (var role in roles)
        {
            await _repository.CreateAsync(new Entities.UserRole() { UserId = user.Id, RoleId = role.Id });
        }
    }

}