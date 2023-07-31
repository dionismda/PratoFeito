namespace _Shared.ValueObjects._Commons;

public class Money : ValueObject<Money>
{
    public decimal Amount { get; private set; }

    protected Money() { }

    public Money(decimal amount)
    {
        Amount = amount;
    }

    public Money Add(decimal amount)
    {
        Amount += amount;
        return this;
    }

    public Money Multiply(int value)
    {
        Amount *= value;
        return this;
    }

    public bool IsGreatThenOrEquals(Money moneyValueObject)
    {
        return Amount >= moneyValueObject.Amount;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Amount;
    }
}
