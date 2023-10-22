using IBGEExplorer.Shared.Entities;
using IBGEExplorer.Cities.UseCases.County.Get;

namespace IBGEExplorer.Cities.Entities;
public class County : Entity<int>
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public int IdState { get; set; }
    
    public State State { get; private set; } = null!;
    public IBGE City { get; private set; } = null!;

    public void SetState(State state) =>
        State = state;


    public static implicit operator Response(County county) =>
        new Response(county.Code, county.Name, county.State.Name);
}