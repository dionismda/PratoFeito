namespace _Architecture.Application.Responses;

public sealed class ResponseSuccess<TObject> : IResponse<TObject?>
{
    [DefaultValue(ResponseEnum.Success)]
    public ResponseEnum Type { get; private set; }

    [DefaultValue("Request completed successfully")]
    public string Message { get; private set; }
    public TObject? Result { get; private set; }
    public ResponseSuccess(string message, TObject? result)
    {
        Type = ResponseEnum.Success;
        Message = message;
        Result = result;
    }
}