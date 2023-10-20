using IBGEExplorer.Shared.Entities;

namespace IBGEExplorer.Cities.Entities;
public class City : Entity
{
    public string IdCode { get; set; }
    public string CityName { get; set; }
    public string StateName { get; set; }

}
