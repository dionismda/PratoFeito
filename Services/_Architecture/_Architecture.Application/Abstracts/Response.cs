namespace _Architecture.Application.Abstracts;

public abstract class Response
{
    public ResponseEnum Type { get; private set; }
    public string Message { get; private set; }

    protected Response(ResponseEnum type, string message)
    {
        Type = type;
        Message = message;
    }
}
