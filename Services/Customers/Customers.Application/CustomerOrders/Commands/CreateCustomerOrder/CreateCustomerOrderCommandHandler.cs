namespace Customers.Application.CustomerOrders.Commands.CreateCustomerOrder;

public sealed class CreateCustomerOrderCommandHandler : ICommandHandler<CreateCustomerOrderCommand, CustomerOrder>
{
    private readonly ICustomerOrderRepository _customerOrderRepository;

    public CreateCustomerOrderCommandHandler(ICustomerOrderRepository customerOrderRepository)
    {
        _customerOrderRepository = customerOrderRepository;
    }

    public async Task<CustomerOrder> Handle(CreateCustomerOrderCommand request, CancellationToken cancellationToken)
    {
        var customerOrder = new CustomerOrder(request.CustomerId, request.OrderTotal);

        _customerOrderRepository.Insert(customerOrder);

        await _customerOrderRepository.CommitAsync(cancellationToken);

        return customerOrder;
    }
}
