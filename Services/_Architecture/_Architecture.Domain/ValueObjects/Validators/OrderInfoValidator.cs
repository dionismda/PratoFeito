namespace _Architecture.Domain.ValueObjects.Validators;

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

        RuleForEach(x => x.OrderItemInfos)
            .SetValidator(new OrderItemInfoValidator());
    }
}
