using Restaurants.Domain.Restaurants.Aggregates.RestaurantMenus.Entities;

namespace Restaurants.Domain.Restaurants.Aggregates.RestaurantMenus.Entities.Validators;

public sealed class RestaurantMenuValidator : AbstractValidator<RestaurantMenu>
{
    public RestaurantMenuValidator()
    {
        RuleForEach(x => x.MenuItems)
            .SetValidator(new MenuItemValidator());

        RuleFor(x => x.MenuVersion)
            .NotEmpty()
            .NotNull()
            .MinimumLength(1)
            .MaximumLength(255);
    }
}
