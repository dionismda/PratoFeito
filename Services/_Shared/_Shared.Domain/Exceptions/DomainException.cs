namespace _Shared.Domain.Exceptions;

public class DomainException : ArgumentException
{
    public DomainException()
    {
    }

    public DomainException(string? message) : base(message)
    {
    }
}
