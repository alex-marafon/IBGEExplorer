using MongoDB.Bson.Serialization.Attributes;

namespace IBGEExplorer.Data.Mongodb.Mapping.City;
public class CityMap
{
    [BsonId] public string Id { get; set; }
    public string IBGECode { get; set; }
    public string CityName { get; set; }
    public string StateName { get; set; } 
    public string UF { get; set; }
    public bool? Active { get;  set; }
}
