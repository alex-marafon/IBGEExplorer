using IBGEExplorer.Cities.UseCases.IBGE.Search.Contracts;

namespace IBGEExplorer.Cities.UseCases.IBGE.Search;
public class ResponseData : IResponseData
{
    public string Message { get; }

    public ResponseData(string message) => Message = message;
}
