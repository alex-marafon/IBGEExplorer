using IBGEExplorer.Shared.Services.Contracts;
using IBGEExplorer.Shared.UseCases;
using IBGEExplorer.Cities.UseCases.State.Create.Contracts;
using IBGEExplorer.Shared.ValueObjects.Exceptions;

namespace IBGEExplorer.Cities.UseCases.State.Create;

public class Handler
{
    private readonly IRepository _repository;
    private readonly ILoggerService _logger;

    public Handler(IRepository repository, ILoggerService logger) =>
        (_repository, _logger) = (repository, logger);

    public async Task<BaseResponse<Entities.State>> CreateAsync(StateRequest request)
    {
        try
        {
            StateException.ThrowIfIsInvalid((request.Code, request.Acronym, request.Name));

            if (await _repository.IsAlreadyRegisteredStateAsync(request.Code))
                return new BaseResponse<Entities.State>($"State with code {request.Code} already exists", "SST-CTA-0001");

            Entities.State state;
            state = request;

            await _repository.CreateAsync(state);

            await _logger.LogAsync($"New state created. {state.Acronym} - Code: {state.Code}");
            return new BaseResponse<Entities.State>(state, 201);
        }
        catch (Exception ex)
        {
            await _logger.LogAsync($"Erro for create new state: {request.Name}. Error {ex.InnerException}");
            return new BaseResponse<Entities.State>($"Erro for create new state: {request.Name}", "STT-CT-A0002", 500);
        }
    }
}