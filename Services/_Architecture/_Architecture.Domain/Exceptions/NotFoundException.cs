namespace _Architecture.Domain.Exceptions;

public sealed class NotFoundException : Exception
{
    public NotFoundException() : base($"Record not found")
    { }

    public NotFoundException(string message) : base(message)
    { }

    public NotFoundException(SerializationInfo info, StreamingContext ctxt) : base(info, ctxt)
    { }
}
