using IBGEExplorer.Cities.UseCases.IBGE.Search;
using IBGEExplorer.Shared.Entities;

namespace IBGEExplorer.Cities.Entities;
public class IBGE : Entity<int>
{
    public string IBGECode { get; set; } = null!;
    public bool? Active { get; private set; }
    public int IdCounty { get; set; }
    public County County { get; set; } = null!;

    public void Activate(bool active)
    {
        Active = active;
    }

    public void UpdateChanges(IBGE city)
    {
        IBGECode = city.IBGECode;
        County = city.County;
    }

    public static implicit operator Response(IBGE city) =>
        new Response(city.IBGECode, city.County.State.Name, city.County.Name);
}