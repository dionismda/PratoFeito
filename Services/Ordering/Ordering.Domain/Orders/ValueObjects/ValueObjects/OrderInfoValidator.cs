namespace Ordering.Domain.Orders.ValueObjects.ValueObjects;

public class OrderInfoValidator : AbstractValidator<OrderInfo>
{
    public OrderInfoValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.RestaurantId)
            .NotEmpty()
            .NotNull();

        RuleForEach(x => x.OrderItems)
            .SetValidator(new OrderItemValidator());
    }
}
