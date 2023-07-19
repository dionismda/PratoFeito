namespace _Architecture.Application.Responses;

public class ResponseWarning<TObject> : IResponse
{
    [DefaultValue(ResponseEnum.Warning)]
    public ResponseEnum Type { get; set; }

    [DefaultValue("Alguns erros foram encontrados")]
    public string Message { get; private set; }
    public TObject? Result { get; private set; }

    public ResponseWarning(string message, TObject? result)
    {
        Type = ResponseEnum.Warning;
        Message = message;
        Result = result;
    }
}