namespace _Architecture.Domain.Abstractions;

public abstract class NotificationDomainService : INotificationDomainService
{
    private readonly Dictionary<string, List<string>> _errors;

    protected NotificationDomainService()
    {
        _errors = new Dictionary<string, List<string>>();
    }

    public void AddError(string index, string errorMessage)
    {
        if (_errors.TryGetValue(index, out var listError))
        {
            _errors[index].Add(errorMessage);
        }
        else
        {
            _errors.Add(index, new List<string> { errorMessage });
        }
    }

    public void ClearErrorList()
    {
        _errors.Clear();
    }

    public bool HasError()
    {
        return _errors.Count > 0;
    }

    public void Validate(string messageError)
    {
        if (HasError())
            throw new NotificationDomainException(messageError, _errors);
    }
}
