namespace _Shared.Application.Features.Responses;

public class ResponseWarning<TObject> : IResponse
{
    public ResponseWarning(string message, TObject? result)
    {
        Type = ResponseTypeEnum.Warning;
        Message = message;
        Result = result;
    }

    [DefaultValue(ResponseTypeEnum.Warning)]
    public ResponseTypeEnum Type { get; set; }

    [DefaultValue("Some bugs were found")]
    public string Message { get; private set; }
    public TObject? Result { get; private set; }
}
