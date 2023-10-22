namespace IBGEExplorer.Cities.UseCases.State.Create;

public class StateRequest
{
    public string Code { get; set; } = null!;
    public string Acronym { get; set; } = null!;
    public string Name { get; set; } = null!;

    public static implicit operator Entities.State(StateRequest request) =>
        new Entities.State() { Code = request.Code, Acronym = request.Acronym, Name = request.Name };
}