namespace _Architecture.Domain.Exceptions;

public class ValidationDomainException : WarningException
{
    public ValidationDomainException(Dictionary<string, List<string>> errors) : base("Some fields are invalid")
    {
        Errors = errors;
    }
}