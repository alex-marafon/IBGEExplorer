namespace IBGEExplorer.Cities.UseCases.IBGE.Search;

public class Response
{
    public Response(string iBGECode, string stateName, string cityName)
    {
        IBGECode = iBGECode;
        StateName = stateName;
        CityName = cityName;
    }

    public string IBGECode { get; set; } = null!;
    public string StateName { get; set; } = null!;
    public string CityName { get; set; } = null!;
}