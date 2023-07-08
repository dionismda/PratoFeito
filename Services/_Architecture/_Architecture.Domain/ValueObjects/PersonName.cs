namespace _Architecture.Domain.ValueObjects;

public class PersonName : ValueObject<PersonName>, IValidation
{
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;

    protected PersonName() { }

    public PersonName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return FirstName;
        yield return LastName;
    }

    public override string? ToString()
    {
        return $"{FirstName} {LastName}";
    }

    public void Validate()
    {
        PersonNameValidator validator = new();

        var result = validator.Validate(this);

        if (!result.IsValid)
            throw new ValidationDomainException(result.GetErrors());
    }
}
