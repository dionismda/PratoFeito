namespace Customers.Domain.Customers.Entities.Valitadors;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(x => x.Name)
            .SetValidator(new PersonNameValidator());

        RuleFor(x => x.OrderLimit)
            .SetValidator(new MoneyValidator());
    }
}
