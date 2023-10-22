using IBGEExplorer.Account.Entities;
using IBGEExplorer.Account.UseCases.Create.Contracts;
using IBGEExplorer.Shared.Extensions;
using IBGEExplorer.Shared.Services.Contracts;
using IBGEExplorer.Shared.UseCases;

namespace IBGEExplorer.Account.UseCases.Create;

public class Handler
{
    private readonly ILoggerService _logger;
    private readonly IRepository _repository;
    private readonly Role.Get.Handler _roleHandler;
    private readonly UserRole.Create.Handler _userRoleHandler;

    public Handler(ILoggerService logger, IRepository repository, 
        Role.Get.Handler roleHandler, UserRole.Create.Handler userRoleHandler)
        => (_logger, _repository, _roleHandler, _userRoleHandler) = (logger, repository, roleHandler, userRoleHandler);

    public async Task<BaseResponse<ResponseData>> CreateAccountAsync(Request account)
    {
        User user;
        List<Entities.Role>? roles;

        #region Validação

        if (!account.Email.Contains("@") || account.Password.Length < 8 || account.Password.Length > 16)
            return new BaseResponse<ResponseData>("User with this email already exists", "ACT-A0001");

        #endregion

        #region Verificar se existe

        bool checkIfAlreadyExists = await _repository.IsAlreadyRegisteredAccountAsync(account.Email);

        if (checkIfAlreadyExists)
            return new BaseResponse<ResponseData>("User with this email already exists", "ACT-A0002");

        #endregion

        #region 03 Criar objeto

        try
        {
            user = account;
            user.SetHashSalt(StringExtensions.CreateSalt());
            user.Password = StringExtensions.GenerateSha256Hash(user.HashSalt, user.Password);
            user.SetHashSalt(StringExtensions.CreateSalt());
            user.Password = StringExtensions.GenerateSha256Hash(user.HashSalt!, user.Password);

            roles = _roleHandler.GetRolesByIds(account.RoleIds);            
        }
        catch (Exception ex)
        {
            return new BaseResponse<ResponseData>(ex.Message, "ACT-A0003", 500);
        }

        #endregion

        #region Persistir os dados

        try
        {
            if(roles is null || !roles.Any())
                return new BaseResponse<ResponseData>("The role Ids are invalid!", "ACT-A0004",400);

            await _repository.Create(user);
            await _userRoleHandler.CreateAsync(user, roles);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
            await _logger.LogAsync($"An error occurred while saving the user in database", "ACT-A0005");
            return new BaseResponse<ResponseData>("An error occurred while saving the user in database", "ACT-A0005",
                400);
        }

        #endregion

        #region Retorno de sucesso

        await _logger.LogAsync($"New account created: {user.Email}");
        return new BaseResponse<ResponseData>(new ResponseData("Account created successfully"), 201);

        #endregion
    }
}