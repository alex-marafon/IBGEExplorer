using IBGEExplorer.Cities.Entities;

namespace IBGEExplorer.Cities.UseCases.Create;

public class CityRequestCreate
{
    public string IBGECode { get; set; } = null!;
    public string StateName { get; set; } = null!;
    public string CityName { get; set; } = null!;

    public static implicit operator City(CityRequestCreate request) =>
    new City()
    {
        IBGECode = request.IBGECode,
        //StateName = request.StateName,
        //CityName = request.CityName
    };
}