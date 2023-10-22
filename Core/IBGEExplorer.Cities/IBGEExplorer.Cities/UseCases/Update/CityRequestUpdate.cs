using IBGEExplorer.Cities.Entities;

namespace IBGEExplorer.Cities.UseCases.Update;

public class CityRequestUpdate
{
    public string IBGECode { get; set; } = null!;
    public Create.CityRequestCreate City { get; set; } = null!;

    public static implicit operator City(CityRequestUpdate update) =>
        new City()
        {
            CityName = update.City.CityName,
            StateName = update.City.StateName,
            IBGECode = update.City.IBGECode,
        };
}