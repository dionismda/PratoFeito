namespace Customers.Application.CustomerOrders.Commands.CreateCustomerOrder;

public sealed class CreateCustomerOrderCommandHandler : ICommandHandler<CreateCustomerOrderCommand, CustomerOrder>
{
    private readonly ICustomerOrderDomainService _customerOrderDomainService;

    public CreateCustomerOrderCommandHandler(ICustomerOrderDomainService customerOrderDomainService)
    {
        _customerOrderDomainService = customerOrderDomainService;
    }

    public async Task<CustomerOrder> Handle(CreateCustomerOrderCommand request, CancellationToken cancellationToken)
    {
        var customerOrder = new CustomerOrder(request.CustomerId, request.OrderTotal);

        await _customerOrderDomainService.InsertAsync(customerOrder, cancellationToken);

        return customerOrder;
    }
}
