namespace _Shared.Application.Features.Responses;

public class ResponseUnauthorized : IResponse
{
    public ResponseUnauthorized(string message, object? result = null)
    {
        Type = ResponseTypeEnum.Error;
        Message = message;
        Result = result;
    }

    [DefaultValue(ResponseTypeEnum.Error)]
    public ResponseTypeEnum Type { get; private set; }

    [DefaultValue("Unauthorized")]
    public string Message { get; private set; }

    [DefaultValue(null!)]
    public object? Result { get; private set; }
}
