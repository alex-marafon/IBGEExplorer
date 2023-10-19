using IBGEExplorer.Account.Entities;
using IBGEExplorer.Account.UseCases.Create.Contracts;
using IBGEExplorer.Shared.Extensions;
using IBGEExplorer.Shared.Services.Contracts;
using IBGEExplorer.Shared.UseCases;
using IBGEExplorer.Shared.ValueObjects;

namespace IBGEExplorer.Account.UseCases.Create;

public class Handler
{
    private readonly ILoggerService _logger;
    private readonly IRepository _repository;

    public Handler(ILoggerService logger, IRepository repository)
        => (_logger, _repository) = (logger, repository);

    public async Task<BaseResponse<ResponseData>> CreateAccountAsync(Request account)
    {
        User user;

        #region Validação

        #endregion

        #region Verificar se existe

        bool checkIfAlreadyExists = await _repository.IsAlreadyRegisteredAccountAsync(account.Email);

        if (checkIfAlreadyExists)
            return new BaseResponse<ResponseData>("User with this email already exists", "2D71FC0D");

        #endregion

        #region 03 Criar objeto

        try
        {
            user = new User
            {
                Id = Guid.NewGuid(),
                Email = account.Email,
                PasswordHash = StringEstensions.ToSha256(account.Password),
               // FullName = new Name("Maria", "das Dores")
               FirstName = "Maria",
               LastName = "das Dores"
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse<ResponseData>(ex.Message, "2D71FC0D");
        }

        #endregion

        #region Persistir os dados

        try
        {
            await _repository.SaveAsync(user);
        }
        catch
        {
            await _logger.LogAsync($"An error occurred while saving the user in database", "EC7B1512");
            return new BaseResponse<ResponseData>("An error occurred while saving the user in database", "EC7B1512",
                400);
        }

        #endregion

        #region Retorno de sucesso

        await _logger.LogAsync($"New account created: {user.Email}");
        return new BaseResponse<ResponseData>(new ResponseData("Account created successfully"));

        #endregion
    }
}