namespace Customer.Domain.Customers.Commands.Handlers;

public sealed class CustomerHandler : ICommandHandler<CreateCustomerCommand, CustomerEntity>
{
    private readonly ICustomerDomainService _customerDomainService;

    public CustomerHandler(ICustomerDomainService customerDomainService)
    {
        _customerDomainService = customerDomainService;
    }

    public async Task<CustomerEntity> Handle(CreateCustomerCommand command, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }
}
