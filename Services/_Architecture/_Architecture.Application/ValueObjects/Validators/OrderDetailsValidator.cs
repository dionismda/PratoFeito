namespace _Architecture.Application.ValueObjects.Validators;

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

        RuleForEach(x => x.OrderItemInfos)
            .SetValidator(new OrderItemInfoValidator());

        RuleFor(x => x.OrderTotal)
            .SetValidator(new MoneyValidator());
    }
}
