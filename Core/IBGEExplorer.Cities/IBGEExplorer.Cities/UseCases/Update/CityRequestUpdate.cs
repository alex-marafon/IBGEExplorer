using IBGEExplorer.Cities.Entities;

namespace IBGEExplorer.Cities.UseCases.Update;

public class CityRequestUpdate
{
    public string IBGECode { get; set; } = null!;
    public Create.CityRequestCreate City { get; set; } = null!;

    public static implicit operator City(CityRequestUpdate update) =>
        new City()
        {
            IBGECode = update.City.IBGECode,
        };
}