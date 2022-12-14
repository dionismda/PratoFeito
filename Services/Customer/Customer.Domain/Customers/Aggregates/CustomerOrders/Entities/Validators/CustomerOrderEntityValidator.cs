namespace Customer.Domain.Customers.Aggregates.CustomerOrders.Entities.Validators;

public class CustomerOrderEntityValidator : AbstractValidator<CustomerOrderEntity>
{
    public CustomerOrderEntityValidator()
    {
        RuleFor(x => x.Customer)
            .SetValidator(new CustomerEntityValidator());

        RuleFor(x => x.OrderTotal)
            .SetValidator(new MoneyValueObjectValidator());

        RuleFor(x => x.OrderState)
            .IsInEnum();
    }
}
