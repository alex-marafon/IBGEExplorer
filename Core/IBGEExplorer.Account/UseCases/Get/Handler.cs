using IBGEExplorer.Account.Entities;
using IBGEExplorer.Account.UseCases.Get.Contracts;

namespace IBGEExplorer.Account.UseCases.Get;

public class Handler
{
    private readonly IRepository _repository;

    public Handler(IRepository repository) =>
        _repository = repository;
    

    public async Task<User> GetOneByIdAsync(int id)
    {
        var user = await _repository.GetUser(id);
        return user;
    }
    
    //passar um obj como parametro
    public async Task<User> GetOneByEmailPasswordAsync(string email, string password)
    {
        var user = await _repository.GetUser(email, password);
        return user;
    }
}