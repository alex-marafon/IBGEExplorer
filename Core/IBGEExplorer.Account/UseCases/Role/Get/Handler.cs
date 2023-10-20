using IBGEExplorer.Account.UseCases.Role.Get.Contracts;

namespace IBGEExplorer.Account.UseCases.Role.Get;

public class Handler
{
    private readonly IRepository _repository;

    public Handler(IRepository repository) =>
        _repository = repository;

    public List<Entities.Role>? GetRolesByIds(HashSet<int> ids)
    {
        IQueryable<Entities.Role> query = _repository.GetByIdListAsNoTracking();
        var roles = query
            .Where(x => ids.Contains(x.Id))
            .ToList();

        return roles;
    }
}