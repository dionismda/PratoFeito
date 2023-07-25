namespace Ordering.Domain.Orders.Entities.Validators;

public class OrderValidator : AbstractValidator<Order>
{
    public OrderValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.RestaurantId)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.State)
            .IsInEnum();

        RuleForEach(x => x.OrderItems)
            .SetValidator(new OrderItemValidator());
    }
}
