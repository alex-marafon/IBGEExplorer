using ClosedXML.Excel;
using IBGEExplorer.Cities.Entities;
using IBGEExplorer.Cities.UseCases.Import.Contracts;
using IBGEExplorer.Shared.Services.Contracts;
using IBGEExplorer.Shared.UseCases;
using Microsoft.AspNetCore.Http;

namespace IBGEExplorer.Cities.UseCases.Import;
public class Handler
{
    private readonly ILoggerService _logger;
    private readonly IRepository _repository;

    public Handler(IRepository repository, ILoggerService logger)
        => (_logger, _repository) = (logger, repository);


    public static async Task<BaseResponse<ResponseData>> ImportCityAsync(IFormFile file)
    {
        //Verifica se arquivo foi informado
        if (file == null || file.Length == 0)
            return new BaseResponse<ResponseData>(new ResponseData("File not specified"), 400);

        //Verifica tipo do arquivo
        var allowedExtensions = new[] { ".xlsx", ".xls" };
        var fileExtension = Path.GetExtension(file.FileName).ToLower();

        if (!allowedExtensions.Contains(fileExtension))
            return new BaseResponse<ResponseData>(new ResponseData("Invalid file format provide .xlsx or xls file"), 400);

        //Verifica tamanho do arquivo.
        if (file.Length > 512 * 1024)
            return new BaseResponse<ResponseData>(new ResponseData("File must be smaller than 512 kb"), 400);


        //Verificar com time se vai colar mais validação no arquivo.


        //Processando arquivo para a modelagem que queremos.
        var _city = new List<City>();
        int x = 0;
        try
        {
            using (var excelWorkbook = new XLWorkbook(file.OpenReadStream()))
            {
                var abaMinicipio = excelWorkbook.Worksheet(2).RowsUsed().Skip(1);
                var _county = new List<County>();
                var _state = new List<State>();

                foreach (var dataRow in abaMinicipio)
                {
                    var county = new County();
                    county.CodigoMunicipio = dataRow.Cell(1).Value.ToString()?.Trim();
                    county.NomeMunicipio = dataRow.Cell(2).Value.ToString();
                    county.CodigoUfMunicipio = dataRow.Cell(3).Value.ToString().Trim();
                    _county.Add(county);
                }

                var abaUf = excelWorkbook.Worksheet(1).RowsUsed().Skip(1);

                foreach (var dataRow in abaUf)
                {
                    var state = new State();
                    state.CodeUF = dataRow.Cell(1).Value.ToString().Trim();
                    state.UF = dataRow.Cell(2).Value.ToString().Trim();
                    state.UFName = dataRow.Cell(3).Value.ToString();
                    _state.Add(state);
                }

                foreach (var item in _county)
                {
                    var city = new City();
                    var uf = _state.FirstOrDefault(x => x.CodeUF.Equals(item.CodigoUfMunicipio));

                    city.IBGECode = item.CodigoMunicipio;
                    city.CityName = item.NomeMunicipio;
                    city.UFSigla = uf.UF;
                    city.UFName = uf.UFName;
                    _city.Add(city);
                    x++;
                }
            }
        }
        catch (Exception ex)
        {
           // await _logger.LogAsync($"Error process file: {ex.Message}");
            return new BaseResponse<ResponseData>(new ResponseData("Error process file:"), 400);
        }

        //Se tudo correr bem.
        //await _repository.SaveListCityAsync(_city);
       // await _logger.LogAsync($"News cities created");
        return new BaseResponse<ResponseData>(new ResponseData("Cities created successfully"), 201);
    }
}



//Reclama do logger e do repository pq nao sao static 