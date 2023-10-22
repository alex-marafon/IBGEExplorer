using IBGEExplorer.Cities.Entities;
using IBGEExplorer.Shared.Services.Contracts;
using IBGEExplorer.Shared.UseCases;
using IBGEExplorer.Shared.ValueObjects.Exceptions;
using IBGEExplorer.Cities.UseCases.State.Get;
using IBGEExplorer.Cities.UseCases.County.Get;
using IBGEExplorer.Cities.UseCases.IBGE.Create.Contracts;

namespace IBGEExplorer.Cities.UseCases.IBGE.Create;

public class Handler
{
    private readonly IRepository _repository;
    private readonly ILoggerService _logger;
    private readonly State.Get.Handler _stateHandler;
    private readonly County.Get.Handler _countyHandler;

    public Handler(IRepository repository, ILoggerService logger, State.Get.Handler stateHandler, County.Get.Handler countyHandler) =>
        (_repository, _logger, _stateHandler, _countyHandler) = (repository, logger, stateHandler, countyHandler);

    public async Task<BaseResponse<Entities.IBGE>> CreateAsync(CityRequestCreate request)
    {
        try
        {
            CityException.ThrowIfIsInvalid((request.IBGECode, request.CountyCode, request.StateCode));

            //Calcular digito verificador


            if (await _repository.IsAlreadyRegisteredAccountAsync(request.IBGECode))
                return new BaseResponse<Entities.IBGE>($"City with IBGECode {request.IBGECode} already exists", "CTY--CTA0003");

            var state = await _stateHandler.GetOneByCodeAsnoTrackingAsync(request.StateCode);
            if (state is null)
                return new BaseResponse<Entities.IBGE>($"State with code {request.StateCode} not nout", "CTY--CTA0001");

            var county = await _countyHandler.GetOneByCodeAsnoTrackingAsync(request.CountyCode);
            if (county is null)
                return new BaseResponse<Entities.IBGE>($"county with code {request.StateCode} not nout", "CTY--CTA0002");

            var city = new Entities.IBGE() { IBGECode = request.IBGECode, IdCounty = county.Id };

            await _repository.CreateAsync(city);

            await _logger.LogAsync($"New city created. IBGE code: {city.IBGECode}");
            return new BaseResponse<Entities.IBGE>(city, 201);
        }
        catch (Exception ex)
        {
            await _logger.LogAsync($"Erro for create new city: {request.IBGECode}. Error {ex.InnerException}");
            return new BaseResponse<Entities.IBGE>($"Erro for create new city: {request.IBGECode}", "CTY-CT-A0004", 500);
        }
    }
}