namespace _Architecture.Domain.Abstractions;

public abstract class WarningException : Exception
{
    public Dictionary<string, List<string>> Errors { get; protected set; } = new();

    protected WarningException()
    {
    }

    protected WarningException(string? message) : base(message)
    {
    }

    protected WarningException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected WarningException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}