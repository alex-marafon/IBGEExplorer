namespace IBGEExplorer.Cities.UseCases.Search;

public class Response
{
    public Response(string iBGECode, string stateName, string cityName,string uf )
    {
        IBGECode = iBGECode;
        StateName = stateName;
        CityName = cityName;
        UF = uf;
        
    }

    public string IBGECode { get; set; } = null!;
    public string StateName { get; set; } = null!;
    public string CityName { get; set; } = null!;
    public string UF { get; set; } = null!;


}