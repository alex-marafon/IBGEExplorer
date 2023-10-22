namespace IBGEExplorer.Cities.UseCases.Update;

public class CityRequestUpdate
{
    public string IBGECode { get; set; } = null!;
    public string StateCode { get; set; } = null!;
    public string CountyCode { get; set; } = null!;

    public static implicit operator Entities.IBGE(CityRequestUpdate update) =>
        new Entities.IBGE()
        {
            IBGECode = update.IBGECode,
        };
}