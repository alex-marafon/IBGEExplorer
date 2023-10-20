using IBGEExplorer.Cities.UseCases.Import.Contracts;

namespace IBGEExplorer.Cities.UseCases.Import;
public class ResponseData : IResponseData
{
    public string Message { get; }

    public ResponseData(string message) => Message = message;
}
