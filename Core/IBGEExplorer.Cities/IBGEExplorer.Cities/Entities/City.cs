using IBGEExplorer.Shared.Entities;

namespace IBGEExplorer.Cities.Entities;
public class City : Entity
{
    public string IBGECode { get; set; } = null;
    public string CityName { get; set; } = null;
    public string UFSigla { get; set; } = null;
    public string UFName { get; set; } = null;

}