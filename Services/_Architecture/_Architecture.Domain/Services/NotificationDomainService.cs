namespace Architecture.Domain.Services;

public sealed class NotificationDomainService : INotificationDomainService
{
    private readonly Dictionary<string, List<string>> _errors;

    public NotificationDomainService()
    {
        _errors = new Dictionary<string, List<string>>();
    }

    public void AddError(string index, string errorMessage)
    {
        if (_errors.TryGetValue(index, out List<string>? listError))
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
