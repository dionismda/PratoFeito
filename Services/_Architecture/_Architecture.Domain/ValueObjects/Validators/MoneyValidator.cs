namespace _Architecture.Domain.ValueObjects.Validators;

public class MoneyValidator : AbstractValidator<Money>
{
    public MoneyValidator()
    {
        RuleFor(x => x.Amount)
            .NotNull()
            .NotEmpty()
            .GreaterThanOrEqualTo(0)
            .PrecisionScale(4, 2, false);
    }
}
