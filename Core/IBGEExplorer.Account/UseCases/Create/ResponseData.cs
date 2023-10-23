using IBGEExplorer.Account.UseCases.Create.Contracts;

namespace IBGEExplorer.Account.UseCases.Create;

public class ResponseData : IResponseData
{
    public string Message { get; }
    
    public ResponseData(string message) => Message = message;
}