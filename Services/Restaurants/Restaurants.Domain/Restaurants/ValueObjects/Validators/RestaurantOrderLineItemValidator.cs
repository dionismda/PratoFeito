namespace Restaurants.Domain.Restaurants.ValueObjects.Validators;

public sealed class RestaurantOrderLineItemValidator : AbstractValidator<RestaurantOrderLineItem>
{
    public RestaurantOrderLineItemValidator()
    {
        RuleFor(x => x.MenuItemId)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .MinimumLength(1);

        RuleFor(x => x.Quantity)
            .NotEmpty()
            .NotNull()
            .GreaterThanOrEqualTo(1);
    }
}
