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



    public async Task<BaseResponse<City>> GetOneByIdAsync(int id)
    {
        var city = await _repository.GetCityByIdAsNoTracking(id);
        if (city is null)
            return new BaseResponse<City>("City with id {id} not found", "CIT-B0001");

        return new BaseResponse<City>(city);
    }




}