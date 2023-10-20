using IBGEExplorer.Account.Entities;

namespace IBGEExplorer.Account.UseCases.Get.Contracts;

public interface IRepository
{
    Task<User?> GetUserById(int id);
    Task<User?> GetUserByIdAsNoTracking(int id);
    Task<User?> GetUserByEmailAsNoTracking(string email);
}