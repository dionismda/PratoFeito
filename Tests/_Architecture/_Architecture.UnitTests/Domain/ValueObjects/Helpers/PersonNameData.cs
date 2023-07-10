namespace _Architecture.UnitTests.Domain.ValueObjects.Helpers;

public static class PersonNameData
{
    public static IEnumerable<object[]> InvalidPersonName =>
        new List<object[]>
        {
            new object[] { PersonNameBuilder.New().ChangeFirstName(TestConstants.StringWith80Characters).Build() },
            new object[] { PersonNameBuilder.New().ChangeFirstName(TestConstants.StringWith100Characters).Build() }
        };

    public static IEnumerable<object[]> ValidPersonName =>
        new List<object[]>
        {
            new object[] { PersonNameBuilder.New().Build() },
            new object[] { PersonNameBuilder.New().Build() }
        };
}
