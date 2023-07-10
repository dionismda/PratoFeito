namespace _Architecture.UnitTests._Commons.Builders;

public sealed class MoneyBuilder : Builders<MoneyBuilder, Money>
{
    private decimal Amount { get;  set; }

    public MoneyBuilder()
    {
        Amount = Bogus.Random.Long(1, 100);
    }

    public MoneyBuilder ChangeAmount(decimal amount)
    {
        Amount = amount;
        return this;
    }

    public override Money Build()
    {
        return new Money(Amount);
    }
}
