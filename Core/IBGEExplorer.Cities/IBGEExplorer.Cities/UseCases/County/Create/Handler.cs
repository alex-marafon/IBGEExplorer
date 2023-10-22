using IBGEExplorer.Cities.UseCases.County.Create.Contracts;
using IBGEExplorer.Shared.Services.Contracts;
using IBGEExplorer.Shared.UseCases;
using IBGEExplorer.Shared.ValueObjects.Exceptions;
namespace IBGEExplorer.Cities.UseCases.County.Create;

public class Handler
{
    private readonly IRepository _repository;
    private readonly ILoggerService _logger;
    private readonly State.Get.Handler _stateHandler;

    public Handler(IRepository repository, ILoggerService logger, State.Get.Handler handler) =>
        (_repository, _logger, _stateHandler) = (repository, logger, handler);

    public async Task<BaseResponse<Entities.County>> CreateAsync(CountyRequest request)
    {
        try
        {
            CountyException.ThrowIfIsInvalid((request.Code, request.Name));

            if (await _repository.IsAlreadyRegisteredCountyAsync(request.Code))
                return new BaseResponse<Entities.County>($"Count with code {request.Code} already exists", "CCT-CTA-A0001");

            var state = await _stateHandler.GetOneByIdAsync(request.IdState);
            if(state is null)
                return new BaseResponse<Entities.County>($"State with id {request.IdState} not found", "CCT-CTA-A0002");

            Entities.County county;
            county = request;
            county.SetState(state);

            await _repository.CreateAsync(county);

            await _logger.LogAsync($"New state created. Code: {county.Code}");
            return new BaseResponse<Entities.County>(county, 201);
        }
        catch (Exception ex)
        {
            await _logger.LogAsync($"Erro for create new county: {request.Name}. Error {ex.InnerException}");
            return new BaseResponse<Entities.County>($"Erro for create new county: {request.Name}", "CCT-CT-A0002", 500);
        }
    }
}