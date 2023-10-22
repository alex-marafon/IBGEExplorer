using IBGEExplorer.Cities.UseCases.County.Get.Contracts;
using IBGEExplorer.Shared.Services.Contracts;
using IBGEExplorer.Shared.UseCases;

namespace IBGEExplorer.Cities.UseCases.County.Get;

public class Handler
{
    private readonly IRepository _repository;
    private readonly ILoggerService _logger;

    public Handler(IRepository repository, ILoggerService logger) =>
        (_repository, _logger) = (repository, logger);

    public async Task<BaseResponse<List<Response>?>> GetAllAsync()
    {
        List<Entities.County>? county = await _repository.GetAllAsync();
        List<Response> responses = new List<Response>();
        
        county.ForEach(x =>
        {
            Response response;
            response = x;   

            responses.Add(response);
        });

        return new BaseResponse<List<Response>?>(responses);
    }

    public async Task<Entities.County?> GetOneByCodeAsnoTrackingAsync(string code) =>
        await _repository.GetOneByCodeAsNoTrackingAsync(code);
}