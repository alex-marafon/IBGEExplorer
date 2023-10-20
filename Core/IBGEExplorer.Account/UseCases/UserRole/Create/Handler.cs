using IBGEExplorer.Account.Entities;
using IBGEExplorer.Account.UseCases.UserRole.Create.Contracts;

namespace IBGEExplorer.Account.UseCases.UserRole.Create;

public class Handler
{
    private readonly IRepository _repository;

    public Handler(IRepository repository) =>
        _repository = repository;

    public async Task CreateAsync(User user, Entities.Role role)
    {
        var userRole = new Entities.UserRole() { UserId = user.Id, RoleId = role.Id };
        await _repository.CreateAsync(userRole);
    }

}