namespace _Architecture.Application.Responses;

public sealed class ResponseWarning<TObject> : Response
{
    public TObject? Result { get; private set; }

    public ResponseWarning(string message, TObject? result) : base(ResponseEnum.Warning, message)
    {
        Result = result;
    }
}