namespace _Architecture.Application.Responses;

public sealed class ResponseError : Response
{
    public object? Result { get; private set; }

    public ResponseError(string message, object? result = null) : base(ResponseEnum.Error, message)
    {
        Result = result;
    }
}
