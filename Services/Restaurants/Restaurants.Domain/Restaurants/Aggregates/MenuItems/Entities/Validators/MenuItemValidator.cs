using Restaurants.Domain.Restaurants.Aggregates.MenuItems.Entities;

namespace Restaurants.Domain.Restaurants.Aggregates.MenuItems.Entities.Validators;

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
