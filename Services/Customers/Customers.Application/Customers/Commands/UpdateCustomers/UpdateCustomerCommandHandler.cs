namespace Customers.Application.Customers.Commands.UpdateCustomers;

public sealed class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand, Customer>
{
    private readonly ICustomerDomainService _customerDomainService;

    public UpdateCustomerCommandHandler(ICustomerDomainService customerDomainService)
    {
        _customerDomainService = customerDomainService;
    }

    public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Customer(request.Name, request.OrderLimit);

        await _customerDomainService.UpdateAsync(customer, cancellationToken);

        return customer;
    }
}
