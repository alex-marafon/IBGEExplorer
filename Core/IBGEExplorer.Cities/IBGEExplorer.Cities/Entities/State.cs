using IBGEExplorer.Shared.Entities;

namespace IBGEExplorer.Cities.Entities;
public class State : Entity<int>
{
    public string Code { get; set; } = null!;
    public string Acronym { get; set; } = null!;
    public string Name { get; set; } = null!;

    public List<County> Counties { get; set; } = null!;

    public static implicit operator UseCases.State.Get.Response(State state) =>
        new State { Code = state.Code, Acronym = state.Acronym, Name = state.Name, Counties = state.Counties };
}