using _Shared.ValueObjects.Abstractions;

namespace _Shared.ValueObjects._Commons;

public class PersonName : ValueObject<PersonName>
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
}
