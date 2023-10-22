namespace IBGEExplorer.Cities.UseCases.County.Create;

public class CountyRequest
{
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public int IdState { get; set; }

    public static implicit operator Entities.County(CountyRequest request) =>
        new Entities.County() { Code = request.Code, Name = request.Name, IdState = request.IdState };
}