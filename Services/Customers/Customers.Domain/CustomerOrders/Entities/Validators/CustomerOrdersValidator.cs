namespace Customers.Domain.CustomerOrders.Entities.Validators;

public class CustomerOrdersValidator : AbstractValidator<CustomerOrder>
{
    public CustomerOrdersValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.State)
            .IsInEnum();

        RuleFor(x => x.OrderTotal)
            .SetValidator(new MoneyValidator());
    }
}