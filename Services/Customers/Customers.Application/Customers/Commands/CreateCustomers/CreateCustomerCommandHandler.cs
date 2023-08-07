namespace Customers.Application.Customers.Commands.CreateCustomers;

public sealed class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand, Customer>
{
    private readonly ICustomerDomainService _customerDomainService;

    public CreateCustomerCommandHandler(ICustomerDomainService customerDomainService)
    {
        _customerDomainService = customerDomainService;
    }

    public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Customer(request.Name, request.OrderLimit);

        await _customerDomainService.InsertAsync(customer, cancellationToken);

        return customer;
    }
}