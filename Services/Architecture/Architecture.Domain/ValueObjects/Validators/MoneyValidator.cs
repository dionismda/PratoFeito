namespace Architecture.Domain.ValueObjects.Validators;

public class MoneyValidator : AbstractValidator<Money>
{
    public MoneyValidator()
    {
        RuleFor(x => x.Amount)
            .NotNull()
            .NotEmpty()
            .PrecisionScale(4, 2, false);
    }
}
