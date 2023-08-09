namespace Customers.Application.Customers.Commands.UpdateCustomers;

public sealed class UpdateCustomerCommandValidator : CustomerCommandValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator(ICustomerRepository customerRepository) : base(customerRepository)
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x)
            .MustAsync(async (customer, cancellationToken) =>
            {
                return !await customerRepository.IsNameUniqueAsync(customer.Name, customer.Id, cancellationToken);

            }).WithMessage("Name already exists");
    }
}