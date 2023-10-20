using IBGEExplorer.Shared.Entities;

namespace IBGEExplorer.Cities.Entities;
public class City : Entity
{
    public string IdCode { get; set; } = null!;
    public string CityName { get; set; } = null!;
    public string StateName { get; set; } = null!;

}
