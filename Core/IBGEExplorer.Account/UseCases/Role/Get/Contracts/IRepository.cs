namespace IBGEExplorer.Account.UseCases.Role.Get.Contracts;

public interface IRepository
{
    public Task<Entities.Role> GetOneById(int id);
    public Task<Entities.Role> GetOneByIdAsNoTracking(int id);
    public IQueryable<Entities.Role> GetByIdListAsNoTracking();
}