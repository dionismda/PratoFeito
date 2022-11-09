namespace _Shared.Domain.ValueObjects;

public class PersonNameValueObject
{
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;

    private PersonNameValueObject() { }

    public PersonNameValueObject(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;

        Validate();
    }

    public void Validate()
    {
        PersonNameValueObjectValidator validator = new();

        var result = validator.Validate(this);

        if (!result.IsValid)
            throw new ValidationException(result.Errors);
    }
}
