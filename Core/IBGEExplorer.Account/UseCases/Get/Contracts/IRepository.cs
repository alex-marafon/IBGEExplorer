using IBGEExplorer.Account.Entities;

namespace IBGEExplorer.Account.UseCases.Get.Contracts;

public interface IRepository
{
    Task<User> GetUser(int id);
    Task<User> GetUser(string email, string password);
}