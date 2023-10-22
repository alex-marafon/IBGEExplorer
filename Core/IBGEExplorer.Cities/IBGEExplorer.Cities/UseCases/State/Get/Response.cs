namespace IBGEExplorer.Cities.UseCases.State.Get;

public class Response
{
    public Response(string name, string code, string acronym)
    {
        Name = name;
        Code = code;
        Acronym = acronym;
    }

    public string Name { get; set; }
    public string Code { get; set; }
    public string Acronym { get; set; }
}