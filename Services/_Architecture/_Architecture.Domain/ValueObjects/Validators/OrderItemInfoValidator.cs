namespace _Architecture.Domain.ValueObjects.Validators;

public class OrderItemInfoValidator : AbstractValidator<OrderItemInfo>
{
    public OrderItemInfoValidator()
    {
        RuleFor(x => x.MenuItemId)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Quantity)
            .NotEmpty()
            .NotNull()
            .LessThanOrEqualTo(0);

        RuleFor(x => x.Total)
            .SetValidator(new MoneyValidator());
    }
}
