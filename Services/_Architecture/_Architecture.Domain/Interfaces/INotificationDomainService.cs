namespace Architecture.Domain.Interfaces;

public interface INotificationDomainService
{
    void AddError(string index, string errorMessage);
    void ClearErrorList();
    bool HasError();
    void Validate(string messageError);
}
