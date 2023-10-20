using System.ComponentModel.DataAnnotations;
using IBGEExplorer.Cities.Entities;

namespace IBGEExplorer.Cities.UseCases.Import;
public class Request
{
    [Required(ErrorMessage = "Codico não informado")]
    public string IdCode { get; set; }
    [Required(ErrorMessage = "Cidade não informado")]
    public string CityName { get; set; }
    [Required(ErrorMessage = "Estado não informado")]
    public string StateName { get; set; }


    public static implicit operator City(Request request) =>
        new City()
        {
            IdCode = request.IdCode,
            CityName = request.CityName,
            StateName = request.StateName,
        };
}