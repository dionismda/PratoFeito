namespace _Architecture.UnitTests._Commons.Builders;

public sealed class PersonNameBuilder : Builders<PersonNameBuilder, PersonName>
{
    private string FirstName { get; set; }
    private string LastName { get; set; }

    public PersonNameBuilder()
    {
        FirstName = Bogus.Name.FirstName();
        LastName = Bogus.Name.LastName();
    }

    public PersonNameBuilder ChangeFirstName(string firstName)
    {
        FirstName = firstName;
        return this;
    }

    public PersonNameBuilder ChangeLastName(string lastName)
    {
        LastName = lastName;
        return this;
    }

    public override PersonName Build()
    {
        return new PersonName(FirstName, LastName);
    }
}
