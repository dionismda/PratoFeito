namespace _Architecture.UnitTests.Domain.ValueObjects;

public sealed class MoneyTest
{
    private Money Money { get; set; }

    public MoneyTest()
    {
        Money = MoneyBuilder.New().Build();
    }

    [Fact]
    public void Money_MustCreateObject_WhenIsValid()
    {
        Assert.NotNull(Money);
    }

    [Theory]
    [InlineData(100)]
    [InlineData(1000)]
    [InlineData(10000)]
    public void Money_MustReturnException_WhenAmountIsInvalid(decimal invalidAmount)
    {
        Assert.Throws<ValidationDomainException>(() =>
        {
            var personName = MoneyBuilder.New().ChangeAmount(invalidAmount).Build();
            personName.Validate();
        });
    }

    [Fact]
    public void Money_MustAddTwoValues()
    {
        var money = MoneyBuilder.New().ChangeAmount(1).Build();
        money.Add(10);

        Assert.NotNull(money);
        Assert.True(money.Amount == 11);
    }

    [Fact]
    public void Money_MustMultiplyTwoValues()
    {
        var money = MoneyBuilder.New().ChangeAmount(1).Build();
        money.Multiply(10);

        Assert.NotNull(money);
        Assert.True(money.Amount == 10);
    }

}
