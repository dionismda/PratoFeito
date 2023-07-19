namespace _Architecture.Application.Responses;

public sealed class ResponseError : IResponse<object?>
{
    [DefaultValue(ResponseEnum.Error)]
    public ResponseEnum Type { get; private set; }

    [DefaultValue("The input is not a valid Base-64 string as it contains a non-base 64 character, more than two padding characters, or an illegal character among the padding characters")]
    public string Message { get; private set; }
    public object? Result { get; private set; }
    public ResponseError(string message, object? result = null)
    {
        Type = ResponseEnum.Error;
        Message = message;
        Result = result;
    }
}
