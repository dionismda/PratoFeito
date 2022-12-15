namespace _Shared.Kernel.Responses;

public class ResponseSuccess<TObject> : IResponse
{
    public ResponseSuccess(string message, TObject? result)
    {
        Type = ResponseTypeEnum.Success;
        Message = message;
        Result = result;
    }

    [DefaultValue(ResponseTypeEnum.Success)]
    public ResponseTypeEnum Type { get; private set; }

    [DefaultValue("Requisição finalizada com sucesso")]
    public string Message { get; private set; }
    public TObject? Result { get; private set; }
}