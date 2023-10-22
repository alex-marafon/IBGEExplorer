namespace IBGEExplorer.Cities.UseCases.State.Get.Contracts;

public interface IRepository
{
    Task<Entities.State?> GetOneByCodeAsync(string code);
    Task<Entities.State?> GetOneByCodeAsnoTrackingAsync(string code);
    Task<Entities.State?> GetOneByIdAsync(int id);
    Task<List<Entities.State>?> GetAllAsync();
}