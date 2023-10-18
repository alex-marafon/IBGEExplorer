using IBGEExplorer.Shared.UseCases.Contracts;
using IBGEExplorer.Shared.ValueObjects;

namespace IBGEExplorer.Shared.UseCases;

public class BaseResponse<TData> : IResponse
{
    private readonly IList<Error>? _errors;
    public TData? Data { get; }
    public int StatusCode { get; }
    
    public bool IsSuccess => StatusCode <= 399;
    public IReadOnlyCollection<Error>? Errors
        => _errors?.ToArray();

    public BaseResponse(TData data, int statusCode = 200)
    {
        Data = data;
        StatusCode = statusCode;
    }
    
    public BaseResponse(string error, string key, int statusCode = 400)
    {
        _errors = new List<Error>();
        _errors.Add(new Error(error, key));
        StatusCode = statusCode;
    }
}