namespace Ordering.Domain.Orders.Aggregates.Validators;

public class OrderItemValidator : AbstractValidator<OrderItem>
{
    public OrderItemValidator()
    {
        RuleFor(x => x.MenuItemId)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(50);

        RuleFor(x => x.Price)
            .SetValidator(new MoneyValidator());

        RuleFor(x => x.Quantity)
            .NotEmpty()
            .NotNull()
            .LessThanOrEqualTo(0);

        RuleFor(x => x.Total)
            .SetValidator(new MoneyValidator());
    }
}
