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

    public async Task<BaseResponse<City>> UpateAsync(CityRequestUpdate request)
    {
        try
        {
            CityException.ThrowIfIsInvalid((request.City.IBGECode, request.City.StateName, request.City.CityName));

            var city = await _repository.GetOneByIBGECodeUpateAsync(request.IBGECode);
            if (city is null)
                return new BaseResponse<City>($"City with IBGECode {request.IBGECode} not found", "CTY-UP-A0001", 404);

            var editCity = request;
            city.UpdateChanges(editCity);

            await _repository.UpateAsync(city);
            await _logger.LogAsync($"City updated. IBGE code: {city.IBGECode}");

            return new BaseResponse<City>(editCity, 201);
        }
        catch(Exception ex)
        {
            await _logger.LogAsync($"Error for update city: {request.IBGECode}. Error {ex.InnerException}");
            return new BaseResponse<City>($"Error for update city", "CTY-UP-B0001", 500);
        }
    }

    public async Task<BaseResponse<City>> DeleteAsync(string IBGECode)
    {
        try
        {
            var city = await _repository.GetOneByIBGECodeUpateAsync(IBGECode);
            if (city is null)
                return new BaseResponse<City>($"City with IBGECode {IBGECode} not found", "CTY-UP-B0001");
            city.Activate(false);

            await _repository.UpateAsync(city);
            await _logger.LogAsync($"City desactivated. IBGE code: {city.IBGECode}");

            return new BaseResponse<City>(city);
        }
        catch(Exception ex)
        {
            await _logger.LogAsync($"Error for delete city: {IBGECode}. Error {ex.InnerException}");
            return new BaseResponse<City>($"Error for delete city", "CTY-UP-B0001");
        }
    }
}