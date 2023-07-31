namespace Restaurants.Domain.RestaurantOrders.Entities.Validators;

public sealed class RestaurantOrderValidator : AbstractValidator<RestaurantOrder>
{
    public RestaurantOrderValidator()
    {
        RuleFor(x => x.RestaurantId)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.State)
            .IsInEnum();

        RuleForEach(x => x.RestaurantOrderLineItem)
            .SetValidator(new RestaurantOrderItemValidator());
    }
}
