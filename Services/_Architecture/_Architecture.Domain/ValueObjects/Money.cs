namespace _Architecture.Domain.ValueObjects;

public class Money : ValueObject<Money>, IValidation
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

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
    }

    public void Validate()
    {
        MoneyValidator validator = new();

        var result = validator.Validate(this);

        if (!result.IsValid)
            throw new ValidationDomainException(result.GetErrors());
    }
}
