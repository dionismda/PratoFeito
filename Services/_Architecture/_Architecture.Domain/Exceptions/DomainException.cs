namespace _Architecture.Domain.Exceptions;

public class DomainException : WarningException
{
    public DomainException(string message, string errorMessage, string paramName) : base(message)
    {
        Errors.Add(paramName, new List<string> { errorMessage });
    }

    public DomainException(string message, Dictionary<string, List<string>> errors) : base(message)
    {
        Errors = errors;
    }
}