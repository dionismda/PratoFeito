namespace Customer.Domain.Customers.Entities.Validators;

public class CustomerEntityValidator : AbstractValidator<CustomerEntity>
{
    public CustomerEntityValidator()
    {
        RuleFor(x => x.Name)
            .SetValidator(new PersonNameValueObjectValidator());

        RuleFor(x => x.OrderLimit)
            .SetValidator(new MoneyValueObjectValidator());
    }
}
