namespace Restaurants.Domain.Restaurants.ValueObjects.Validators;

public sealed class RestaurantMenuValidator : AbstractValidator<RestaurantMenu>
{
    public RestaurantMenuValidator()
    {
        RuleForEach(x => x.Items)
            .SetValidator(new MenuItemValidator());

        RuleFor(x => x.MenuVersion)
            .NotEmpty()
            .NotNull()
            .MinimumLength(1);
    }
}
