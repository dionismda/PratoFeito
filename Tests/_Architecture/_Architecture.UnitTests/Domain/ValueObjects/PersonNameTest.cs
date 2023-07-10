namespace _Architecture.UnitTests.Domain.ValueObjects;

public sealed class PersonNameTest
{
    private PersonName Name { get; set; }

    public PersonNameTest()
    {
        Name = PersonNameBuilder.New().Build();
    }

    [Fact]
    public void PersonName_MustCreateObject_WhenIsValid()
    {
        Assert.NotNull(Name);
    }

    [Theory]
    [InlineData("")]
    [InlineData(TestConstants.StringWith2Characters)]
    [InlineData(TestConstants.StringWith60Characters)]
    public void PersonName_MustReturnException_WhenFirstNameIsInvalid(string invalidFirstName)
    {
        Assert.Throws<ValidationDomainException>(() =>
        {
            var personName = PersonNameBuilder.New().ChangeFirstName(invalidFirstName).Build();
            personName.Validate();
        });
    }

    [Theory]
    [InlineData("")]
    [InlineData(TestConstants.StringWith2Characters)]
    [InlineData(TestConstants.StringWith255Characters)]
    public void PersonName_MustReturnException_WhenLastNameIsInvalid(string invalidLastName)
    {
        Assert.Throws<ValidationDomainException>(() =>
        {
            var personName = PersonNameBuilder.New().ChangeLastName(invalidLastName).Build();
            personName.Validate();
        });
    }
}
