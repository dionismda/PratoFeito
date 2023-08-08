namespace Customers.Application.Customers.Commands.UpdateCustomers;

public sealed class UpdateCustomerCommandValidator : CustomerCommandValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator(ICustomerRepository customerRepository) : base(customerRepository)
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull();
    }
}