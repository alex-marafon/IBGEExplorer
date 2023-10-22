namespace IBGEExplorer.Cities.UseCases.County.Get.Contracts;

public interface IRepository
{
    Task<List<Entities.County>?> GetAllAsync();
    Task<Entities.County?> GetOneByCode(string code);
    Task<Entities.County?> GetOneByCodeAsNoTrackingAsync(string code);
}