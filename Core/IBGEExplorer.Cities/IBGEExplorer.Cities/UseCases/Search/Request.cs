namespace IBGEExplorer.Cities.UseCases.Search;
public class Request
{
    public string IdCode { get; set; } = null!;
    public string CityName { get; set; } = null!;
    public string StateName { get; set; } = null!;
}