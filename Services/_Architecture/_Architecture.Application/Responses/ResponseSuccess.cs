namespace _Architecture.Application.Responses;

public sealed class ResponseSuccess<TObject> : Response
{
    public TObject? Result { get; private set; }

    public ResponseSuccess(string message, TObject? result) : base(ResponseEnum.Success, message)
    {
        Result = result;
    }
}