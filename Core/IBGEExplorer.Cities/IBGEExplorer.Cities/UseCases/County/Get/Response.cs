namespace IBGEExplorer.Cities.UseCases.County.Get;

public class Response
{
    public Response(string code, string name, string stateName)
    {
        Code = code;
        Name = name;
        StateName = stateName;
    }

    public string Code { get; set; }
    public string Name { get; set; }
    public string StateName { get; set; }
}