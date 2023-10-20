using IBGEExplorer.Account.Entities;
using IBGEExplorer.Account.UseCases.Get.Contracts;
using IBGEExplorer.Account.UseCases.Login;
using IBGEExplorer.Shared.Extensions;
using IBGEExplorer.Shared.Services.Contracts;
using IBGEExplorer.Shared.Services.Jwt;
using IBGEExplorer.Shared.UseCases;

namespace IBGEExplorer.Account.UseCases.Get;

public class Handler
{
    private readonly ILoggerService _logger;
    private readonly IRepository _repository;

    public Handler(IRepository repository, ILoggerService logger)
        => (_logger, _repository) = (logger, repository);


    public async Task<BaseResponse<Response>> GetOneByIdAsync(int id)
    {
        var user = await _repository.GetUserByIdAsNoTracking(id);
        if(user is null) 
            return new BaseResponse<Response>("User with id {id} not found", "USR-B0001");

        Response reponse = user;

        return new BaseResponse<Response>(reponse);
    }
    
    public async Task<BaseResponse<string>> GetOneByEmailPasswordAsync(RequestLogin account)
    {
        try
        {
            var user = await _repository.GetUserByEmailAsNoTracking(account.Email);

            if (user == null)
                return new BaseResponse<string>("Invalid user", "USR-A001");            

            var verificaSenha = StringExtensions.GenerateSha256Hash(user.HashSalt, account.Password);
            if(verificaSenha != user.Password)
                return new BaseResponse<string>("Invalid user", "USR-A002");           

            await _logger.LogAsync($"Return token for user {user.Email}");
            return new BaseResponse<string>(GetToken(user));
        }
        catch
        {
            return new BaseResponse<string>("An error occurred while try get user", "USR-A0003", 500);
        }
    }

    private string GetToken(User user) => 
        TokenService.GenerateToken(user.Id.ToString());
}