using IBGEExplorer.Cities.Entities;
using IBGEExplorer.Cities.UseCases.County.Create;
using IBGEExplorer.Cities.UseCases.State.Create;

namespace IBGEExplorer.Cities.UseCases.IBGE.Create;

public class CityRequestCreate
{
    public string IBGECode { get; set; }
    public string StateCode { get; set; } = null!;
    public string CountyCode { get; set; } = null!;
}