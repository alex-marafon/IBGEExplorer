
using IBGEExplorer.Shared.Entities;

namespace IBGEExplorer.City.Entities;

public class City : Entity<int>
{
    public string IdCode { get; set; }
    public string CityName { get; set; }
    public string StateName { get; set; }

}
