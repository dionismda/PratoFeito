namespace Customers.Application.Customers.Commands.CreateCustomers;

public sealed class CreateCustomerCommandValidator : CustomerCommandValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator(ICustomerRepository customerRepository) : base(customerRepository)
    {
    }
}