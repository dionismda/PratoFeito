namespace Restaurants.Domain.RestaurantOrders.Aggregates.RestaurantOrderItems.Entities.Validators;

public sealed class RestaurantOrderItemValidator : AbstractValidator<RestaurantOrderItem>
{
    public RestaurantOrderItemValidator()
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
