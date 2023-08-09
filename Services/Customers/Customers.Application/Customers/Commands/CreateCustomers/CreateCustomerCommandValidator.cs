namespace Customers.Application.Customers.Commands.CreateCustomers;

public sealed class CreateCustomerCommandValidator : CustomerCommandValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator(ICustomerRepository customerRepository) : base()
    {
        RuleFor(x => x.Name)
            .MustAsync(async (personName, cancellationToken) =>
            {
                return !await customerRepository.IsNameUniqueAsync(personName, cancellationToken);

            }).WithMessage("Name already exists");
    }
}