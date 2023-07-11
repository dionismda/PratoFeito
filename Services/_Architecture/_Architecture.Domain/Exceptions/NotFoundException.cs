namespace _Architecture.Domain.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException() : base($"Record not found")
    { }

    public NotFoundException(string message) : base(message)
    { }

    protected NotFoundException(SerializationInfo info, StreamingContext ctxt) : base(info, ctxt)
    { }
}
