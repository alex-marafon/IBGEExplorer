using IBGEExplorer.Cities.UseCases.Search;
using IBGEExplorer.Shared.Entities;

namespace IBGEExplorer.Cities.Entities;
public class City : Entity<int>
{
    public string IBGECode { get; set; } = null!;
    public string CityName { get; set; } = null!;
    public string StateName { get; set; } = null!;
    public bool? Active { get; private set; }

    public void Activate(bool active)
    {
        Active = active;
    }

    public void UpdateChanges(City city)
    {
        IBGECode = city.IBGECode;
        CityName = city.CityName;
        StateName = city.StateName;
    }

    public static implicit operator Response(City city) =>
        new Response(city.IBGECode,city.StateName, city.CityName);
    
}