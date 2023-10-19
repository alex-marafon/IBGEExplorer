using IBGEExplorer.Account.Entities;
using IBGEExplorer.Account.UseCases.Create;
using IBGEExplorer.Account.UseCases.Get.Contracts;
using IBGEExplorer.Shared.Services.Jwt;
using IBGEExplorer.Shared.UseCases;

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
    
    public async Task<BaseResponse<string>> GetOneByEmailPasswordAsync(Request account)
    {
        try
        {
            var user = await _repository.GetUser(account.Email);

            if (user == null || user.PasswordHash != account.Password)
                return new BaseResponse<string>("Usuario inválido", "USR-A001");

            return new BaseResponse<string>(GetToken(user)); ;
        }
        catch
        {
            return new BaseResponse<string>("Erro ao validar usuario", "USR-A0002", 500);
        }
    }

    private string GetToken(User user) => 
        TokenService.GenerateToken(user.Id.ToString());
    
}