using IBGEExplorer.Cities.UseCases.Import.Contracts;
using IBGEExplorer.Shared.Services.Contracts;

namespace IBGEExplorer.Cities.UseCases.Import;
public class Handler
{
    private readonly ILoggerService _logger;
    private readonly IRepository _repository;

    public Handler(IRepository repository, ILoggerService logger)
        => (_logger, _repository) = (logger, repository);








}