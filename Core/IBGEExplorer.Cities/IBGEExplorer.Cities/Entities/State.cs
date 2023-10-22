using IBGEExplorer.Shared.Entities;

namespace IBGEExplorer.Cities.Entities;
public class State : Entity
{
    public string Code { get; set; } = null!;
    public string Acronym { get; set; } = null!;
    public string Name { get; set; } = null!;

    public List<County> Counties { get; set; } = null!;
}