using IBGEExplorer.Cities.UseCases.Search;
using IBGEExplorer.Shared.Entities;

namespace IBGEExplorer.Cities.Entities;
public class City : Entity<int>
{
    public string IBGECode { get; set; } = null!;
    public bool? Active { get; private set; }
    public string IdCounty { get; set; } = null!;
    public County County { get; set; } = null!;

    public void Activate(bool active)
    {
        Active = active;
    }

    public void UpdateChanges(City city)
    {
        IBGECode = city.IBGECode;
        County = city.County;
    }

    public static implicit operator Response(City city) =>
        new Response(city.IBGECode, city.County.State.Name, city.County.Name);
}