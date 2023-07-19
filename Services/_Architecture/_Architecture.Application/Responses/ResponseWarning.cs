namespace _Architecture.Application.Responses;

public sealed class ResponseWarning<TObject> : IResponse
{
    [DefaultValue(ResponseEnum.Warning)]
    public ResponseEnum Type { get; set; }

    [DefaultValue("Error to save entity")]
    public string Message { get; private set; }
    public TObject? Result { get; private set; }

    public ResponseWarning(string message, TObject? result)
    {
        Type = ResponseEnum.Warning;
        Message = message;
        Result = result;
    }
}