using IBGEExplorer.Cities.UseCases.Search.Contracts;

namespace IBGEExplorer.Cities.UseCases.Search;
public class ResponseData : IResponseData
{
    public string Message { get; }

    public ResponseData(string message) => Message = message;
}
