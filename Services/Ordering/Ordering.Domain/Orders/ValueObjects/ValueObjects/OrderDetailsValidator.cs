namespace Ordering.Domain.Orders.ValueObjects.ValueObjects;

public class OrderDetailsValidator : AbstractValidator<OrderDetails>
{
    public OrderDetailsValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.RestaurantId)
            .NotEmpty()
            .NotNull();

        RuleForEach(x => x.OrderItems)
            .SetValidator(new OrderItemValidator());

        RuleFor(x => x.OrderTotal)
            .SetValidator(new MoneyValidator());
    }
}
