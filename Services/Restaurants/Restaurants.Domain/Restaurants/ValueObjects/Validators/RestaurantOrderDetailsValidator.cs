namespace Restaurants.Domain.Restaurants.ValueObjects.Validators;

public sealed class RestaurantOrderDetailsValidator : AbstractValidator<RestaurantOrderDetails>
{
    public RestaurantOrderDetailsValidator()
    {
        RuleForEach(x => x.OrderLineItems)
            .SetValidator(new RestaurantOrderLineItemValidator());
    }
}
