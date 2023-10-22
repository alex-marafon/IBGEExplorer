using IBGEExplorer.Cities.UseCases.IBGE.Import.Contracts;

namespace IBGEExplorer.Cities.UseCases.IBGE.Import;
public class ResponseData : IResponseData
{
    public string Message { get; }

    public ResponseData(string message) => Message = message;
}
