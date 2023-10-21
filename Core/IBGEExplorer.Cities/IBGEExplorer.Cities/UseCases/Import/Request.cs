using System.ComponentModel.DataAnnotations;
using IBGEExplorer.Cities.Entities;

namespace IBGEExplorer.Cities.UseCases.Import;
public class Request
{
    [Required(ErrorMessage = "Codico não informado")]
    public string IdCode { get; set; } = null!;
    [Required(ErrorMessage = "Cidade não informado")]
    public string CityName { get; set; } = null!;
    [Required(ErrorMessage = "Estado não informado")]
    public string StateName { get; set; } = null!;


    public static implicit operator City(Request request) =>
        new City()
        {
            IBGECode = request.IdCode,
            CityName = request.CityName,
            StateName = request.StateName,
        };
}