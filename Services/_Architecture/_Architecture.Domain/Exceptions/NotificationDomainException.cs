namespace _Architecture.Domain.Exceptions;

public sealed class NotificationDomainException : WarningException
{
    public NotificationDomainException(string message, string errorMessage, string paramName) : base(message)
    {
        Errors.Add(paramName, new List<string> { errorMessage });
    }

    public NotificationDomainException(string message, Dictionary<string, List<string>> errors) : base(message)
    {
        Errors = errors;
    }
}