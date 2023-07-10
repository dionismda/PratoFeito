namespace _Architecture.UnitTests.Domain.ValueObjects.Helpers;

public static class MoneyData
{
    public static IEnumerable<object[]> InvalidMoney =>
        new List<object[]>
        {
            new object[] { MoneyBuilder.New().ChangeAmount(100).Build() },
            new object[] { MoneyBuilder.New().ChangeAmount(1000).Build() },
            new object[] { MoneyBuilder.New().ChangeAmount(10000).Build() },
        };

    public static IEnumerable<object[]> ValidMoney =>
        new List<object[]>
        {
            new object[] { MoneyBuilder.New().Build() },
            new object[] { MoneyBuilder.New().Build() },
            new object[] { MoneyBuilder.New().Build() },
        };
}
