namespace Restaurants.Domain.RestaurantMenus.Entities.Validators;

public sealed class RestaurantMenuValidator : AbstractValidator<RestaurantMenu>
{
    public RestaurantMenuValidator()
    {
        RuleFor(x => x.MenuVersion)
            .NotEmpty()
            .NotNull()
            .MinimumLength(1)
            .MaximumLength(255);

        RuleForEach(x => x.MenuItems)
            .SetValidator(new MenuItemValidator());

        RuleFor(x => x.RestaurantId)
            .NotEmpty()
            .NotNull();
    }
}
