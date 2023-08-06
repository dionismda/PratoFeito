namespace Restaurants.Domain.Restaurants.Aggregates.MenuItems.Entities.Validators;

public sealed class MenuItemValidator : AbstractValidator<MenuItem>
{
    public MenuItemValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .MinimumLength(3)
            .MaximumLength(255);

        RuleFor(x => x.Price)
            .SetValidator(new MoneyValidator());
    }
}
