namespace _Shared.Domain.ValueObjects.Validators;

public class MoneyValueObjectValidator : AbstractValidator<MoneyValueObject>
{
    public MoneyValueObjectValidator()
    {
        RuleFor(x => x.Amount)
            .NotNull()
            .NotEmpty()
            .ScalePrecision(2, 4);
    }
}
