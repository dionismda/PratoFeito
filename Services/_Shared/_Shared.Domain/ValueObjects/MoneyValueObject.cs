namespace _Shared.Domain.ValueObjects
{
    public class MoneyValueObject
    {
        public Decimal Amount { get; private set; }

        public MoneyValueObject(Decimal amount)
        {
            Amount = amount;
        }

        public void Validate()
        {
            MoneyValueObjectValidator validator = new();

            var result = validator.Validate(this);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);
        }

        public MoneyValueObject Add(Decimal amount)
        {
            return new MoneyValueObject(Amount += amount);
        }

        public MoneyValueObject Multiply(int value)
        {
            return new MoneyValueObject(Amount * value);
        }

        public bool IsGreatThenOrEquals(MoneyValueObject moneyValueObject)
        {
            return Amount >= moneyValueObject.Amount;
        }
    }
}
