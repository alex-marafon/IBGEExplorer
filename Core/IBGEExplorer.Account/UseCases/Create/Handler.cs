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

        #region Validação

        #endregion

        #region Verificar se existe

        bool checkIfAlreadyExists = await _repository.IsAlreadyRegisteredAccountAsync(account.Email);

        if (checkIfAlreadyExists)
            return new BaseResponse<ResponseData>("User with this email already exists", "ACT-A0001");

        #endregion

        #region 03 Criar objeto

        try
        {
            user = account;
            user.SetHashSalt(StringEstensions.CreateSalt());
            user.Password = StringEstensions.GenerateSha256Hash(user.HashSalt, user.Password);

            var roles = _roleHandler.GetRolesByIds(account.RoleIds);
            roles.ForEach(async userRole =>
            {
                await _userRoleHandler.CreateAsync(user, userRole);
            });
        }
        catch (Exception ex)
        {
            return new BaseResponse<ResponseData>(ex.Message, "ACT-A0002", 500);
        }

        #endregion

        #region Persistir os dados

        try
        {
            await _repository.Create(user);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
            await _logger.LogAsync($"An error occurred while saving the user in database", "ACT-A0003");
            return new BaseResponse<ResponseData>("An error occurred while saving the user in database", "ACT-A0003",
                400);
        }

        #endregion

        #region Retorno de sucesso

        await _logger.LogAsync($"New account created: {user.Email}");
        return new BaseResponse<ResponseData>(new ResponseData("Account created successfully"), 201);

        #endregion
    }
}