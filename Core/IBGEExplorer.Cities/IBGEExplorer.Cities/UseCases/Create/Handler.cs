using IBGEExplorer.Cities.Entities;
using IBGEExplorer.Cities.UseCases.Create.Contracts;
using IBGEExplorer.Shared.Services.Contracts;
using IBGEExplorer.Shared.UseCases;
using IBGEExplorer.Shared.ValueObjects.Exceptions;

namespace IBGEExplorer.Cities.UseCases.Create;

public class Handler
{
    private readonly IRepository _repository;
    private readonly ILoggerService _logger;

    public Handler(IRepository repository, ILoggerService logger) =>
        (_repository, _logger) = (repository, logger);

    public async Task<BaseResponse<City>> CreateAsync(CityRequestCreate request)
    {
        try
        {
            CityException.ThrowIfIsInvalid((request.IBGECode, request.StateName, request.CityName));

            if (await _repository.IsAlreadyRegisteredAccountAsync(request.IBGECode))
                return new BaseResponse<City>($"City with IBGECode {request.IBGECode} already exists", "CTY--CTA0001");

            City city;
            city = request;

            await _repository.CreateAsync(city);

            await _logger.LogAsync($"New city created. IBGE code: {city.IBGECode}");
            return new BaseResponse<City>(city, 201);
        }
        catch (Exception ex)
        {
            await _logger.LogAsync($"Erro for create new city: {request.IBGECode}. Error {ex.InnerException}");
            return new BaseResponse<City>($"Erro for create new city: {request.IBGECode}", "CTY-CT-A0002", 500);
        }
    }
}