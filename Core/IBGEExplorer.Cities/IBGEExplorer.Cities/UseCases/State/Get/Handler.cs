using IBGEExplorer.Shared.Services.Contracts;
using IBGEExplorer.Cities.UseCases.State.Get.Contracts;
using IBGEExplorer.Shared.UseCases;

namespace IBGEExplorer.Cities.UseCases.State.Get;

public class Handler
{

    private readonly IRepository _repository;
    private readonly ILoggerService _logger;

    public Handler(IRepository repository, ILoggerService logger) =>
        (_repository, _logger) = (repository, logger);

    public async Task<Entities.State?> GetOneByIdAsync(int id) =>
        await _repository.GetOneByIdAsync(id);

    public async Task<Entities.State?> GetOneByCodeAsnoTrackingAsync(string code) =>
        await _repository.GetOneByCodeAsnoTrackingAsync(code);

    public async Task<BaseResponse<List<Entities.State>?>> GetAllAsync()
    {
        List<Entities.State>? states = await _repository.GetAllAsync();
        return new BaseResponse<List<Entities.State>?>(states);
    }
}