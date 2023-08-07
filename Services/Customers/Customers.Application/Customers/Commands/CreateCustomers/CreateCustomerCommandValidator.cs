namespace Customers.Application.Customers.Commands.CreateCustomers;

public sealed class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator(ICustomerRepository customerRepository)
    {
        RuleFor(x => x.Name)
            .SetValidator(new PersonNameValidator());

        RuleFor(x => x.OrderLimit)
            .SetValidator(new MoneyValidator());

        RuleFor(x => x.Name)
            .MustAsync(async (personName, cancellationToken) =>
             {
                 return !await customerRepository.IsNameUniqueAsync(personName, cancellationToken);

             }).WithMessage("Name already exists");
    }
}
