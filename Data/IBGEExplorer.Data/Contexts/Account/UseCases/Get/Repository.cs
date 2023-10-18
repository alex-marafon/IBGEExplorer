using IBGEExplorer.Account.Entities;
using IBGEExplorer.Account.UseCases.Get.Contracts;

namespace IBGEExplorer.Data.Contexts.Account.UseCases.Get;

//usar context
public class Repository : IRepository
{
    public async Task<User> GetUser(int id)
    {
        return new User() {Id = 1, CanLogin = true, Email = "joao@gmail.com", PasswordHash="qawsedrf" };
    }

    public async Task<User> GetUser(string email, string password)
    {
        return new User() { Id = 1, CanLogin = true, Email = "joao@gmail.com", PasswordHash = "qawsedrf" };
    }
}