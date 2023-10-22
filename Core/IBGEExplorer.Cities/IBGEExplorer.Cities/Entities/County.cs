using IBGEExplorer.Shared.Entities;

namespace IBGEExplorer.Cities.Entities;
public class County : Entity
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string IdState { get; set; } = null!;
    public int IdCity { get; set; }

    public State State { get; set; } = null!;
    public City City { get; set; } = null!;
}