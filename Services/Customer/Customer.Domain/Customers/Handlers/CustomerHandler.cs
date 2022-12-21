namespace Customer.Domain.Customers.Handlers;

public sealed class CustomerHandler :
    ICommandHandler<CreateCustomerCommand, CustomerEntity>,
    ICommandHandler<CreateCustomerOrderCommand, CustomerOrderEntity>,
    ICommandHandler<MarkCustomerOrderAsDeliveredCommand, CustomerOrderEntity>
{
    private readonly ICustomerDomainService _customerDomainService;

    public CustomerHandler(ICustomerDomainService customerDomainService)
    {
        _customerDomainService = customerDomainService;
    }

    public async Task<CustomerEntity> Handle(CreateCustomerCommand command, CancellationToken cancellation)
    {
        var customer = new CustomerEntity(command.PersonName, command.OrderLimit);

        var result2 = await _customerDomainService.GetAllAsync(cancellation, null, null, null);

        return await _customerDomainService.InsertAsync(customer, cancellation);
    }

    public async Task<CustomerOrderEntity> Handle(CreateCustomerOrderCommand command, CancellationToken cancellation)
    {
        var customer = await _customerDomainService.GetByIdAsync(command.CustomerId, cancellation);

        if (customer == null)
            throw new ArgumentNullException($"{command.CustomerId} not found");

        var customerOrder = new CustomerOrderEntity(customer, command.OrderTotal);

        return await _customerDomainService.InsertAsync(customerOrder, cancellation);
    }

    public async Task<CustomerOrderEntity> Handle(MarkCustomerOrderAsDeliveredCommand command, CancellationToken cancellation)
    {
        var customerOrder = await _customerDomainService.GetCustomerOrderByIdAsync(command.CustomerOrderId, cancellation);

        if (customerOrder == null)
            throw new ArgumentNullException($"{command.CustomerOrderId} not found");

        customerOrder.AsDevlivered();

        return await _customerDomainService.UpdateAsync(customerOrder, cancellation);
    }
}
