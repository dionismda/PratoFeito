namespace Restaurants.Domain.Restaurants.ValueObjects.Validators;

public sealed class MenuItemValidator : AbstractValidator<MenuItem>
{
    public MenuItemValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .MinimumLength(3);

        RuleFor(x => x.Price)
            .SetValidator(new MoneyValidator());
    }
}
