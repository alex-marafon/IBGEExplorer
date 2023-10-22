using IBGEExplorer.Cities.Entities;
using IBGEExplorer.Cities.UseCases.Update.Contracts;
using IBGEExplorer.Shared.Services.Contracts;
using IBGEExplorer.Shared.UseCases;
using IBGEExplorer.Shared.ValueObjects.Exceptions;

namespace IBGEExplorer.Cities.UseCases.Update;

public class Handler
{
    private readonly IRepository _repository;
    private readonly ILoggerService _logger;

    public Handler(IRepository repository, ILoggerService logger) =>
        (_repository, _logger) = (repository, logger);

    public async Task<BaseResponse<Entities.IBGE>> UpateAsync(CityRequestUpdate request)
    {
        try
        {
            CityException.ThrowIfIsInvalid((request.IBGECode, request.CountyCode, request.StateCode));

            var city = await _repository.GetOneByIBGECodeUpateAsync(request.IBGECode);
            if (city is null)
                return new BaseResponse<Entities.IBGE>($"City with IBGECode {request.IBGECode} not found", "CTY-UP-A0001", 404);

            var editCity = request;
            city.UpdateChanges(editCity);

            await _repository.UpateAsync(city);
            await _logger.LogAsync($"City updated. IBGE code: {city.IBGECode}");

            return new BaseResponse<Entities.IBGE>(editCity, 201);
        }
        catch(Exception ex)
        {
            await _logger.LogAsync($"Error for update city: {request.IBGECode}. Error {ex.InnerException}");
            return new BaseResponse<Entities.IBGE>($"Error for update city", "CTY-UP-B0001", 500);
        }
    }

    public async Task<BaseResponse<Entities.IBGE>> DeleteAsync(string IBGECode)
    {
        try
        {
            var city = await _repository.GetOneByIBGECodeUpateAsync(IBGECode);
            if (city is null)
                return new BaseResponse<Entities.IBGE>($"City with IBGECode {IBGECode} not found", "CTY-UP-B0001");
            city.Activate(false);

            await _repository.UpateAsync(city);
            await _logger.LogAsync($"City desactivated. IBGE code: {city.IBGECode}");

            return new BaseResponse<Entities.IBGE>(city);
        }
        catch(Exception ex)
        {
            await _logger.LogAsync($"Error for delete city: {IBGECode}. Error {ex.InnerException}");
            return new BaseResponse<Entities.IBGE>($"Error for delete city", "CTY-UP-B0001");
        }
    }
}