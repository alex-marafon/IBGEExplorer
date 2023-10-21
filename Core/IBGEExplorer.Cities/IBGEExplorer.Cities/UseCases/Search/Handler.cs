using IBGEExplorer.Cities.Entities;
using IBGEExplorer.Cities.UseCases.Search.Contracts;
using IBGEExplorer.Shared.Services.Contracts;
using IBGEExplorer.Shared.UseCases;

namespace IBGEExplorer.Cities.UseCases.Search;
public class Handler
{
    private readonly ILoggerService _logger;
    private readonly IRepository _repository;

    public Handler(IRepository repository, ILoggerService logger)
        => (_logger, _repository) = (logger, repository);

    private static BaseResponse<List<Response>> BuildResponse(string cityName, List<City>? cities)
    {
        if (cities is null)
            return new BaseResponse<List<Response>>($"None City was found {cityName}", "CIT-GT-B0001", 404);

        List<Response> responses = new List<Response>();
        cities.ForEach(x =>
        {
            Response response = x;
            responses.Add(response);
        });

        return new BaseResponse<List<Response>>(responses);
    }

    public async Task<BaseResponse<List<Response>>> GetByStateNameAsync(string stateName)
    {
        var cities = await _repository.GetCityByStateAsNoTracking(stateName);
        return BuildResponse(stateName, cities);
    }

    public async Task<BaseResponse<List<Response>>> GetByCityNameAsync(string cityName)
    {
        var cities = await _repository.GetByCityNameAsNoTracking(cityName);
        return BuildResponse(cityName, cities);
    }

    public async Task<BaseResponse<Response>> GetOneByIBGECodeAsync(string IBGECode)
    {
        var city = await _repository.GetCityByCodeAsNoTracking(IBGECode);
        if (city is null)
            return new BaseResponse<Response>($"City with IBGECode {IBGECode} not found", "CIT-GT-B0001", 404);

        Response response = city;

        return new BaseResponse<Response>(response);
    }
}