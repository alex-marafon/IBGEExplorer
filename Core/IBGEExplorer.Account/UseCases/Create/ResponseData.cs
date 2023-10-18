namespace IBGEExplorer.Account.UseCases.Create.Contracts;

public class ResponseData : IResponseData
{
    public string Message { get; }
    
    public ResponseData(string message) => Message = message;
}