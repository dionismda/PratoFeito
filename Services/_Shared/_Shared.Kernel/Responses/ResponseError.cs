namespace _Shared.Kernel.Responses;

public class ResponseError : IResponse
{
    public ResponseError(string message, object? result = null)
    {
        Type = ResponseTypeEnum.Error;
        Message = message;
        Result = result;
    }

    [DefaultValue(ResponseTypeEnum.Error)]
    public ResponseTypeEnum Type { get; private set; }

    [DefaultValue("The input is not a valid Base-64 string as it contains a non-base 64 character, more than two padding characters, or an illegal character among the padding characters")]
    public string Message { get; private set; }

    [DefaultValue(null!)]
    public object? Result { get; private set; }
}
