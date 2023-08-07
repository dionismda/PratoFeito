namespace Customers.Application.CustomerOrders.Commands.DelivereCustomerOrder;

public class DeliveredCustomerOrderCommandHandler : ICommandHandler<DeliveredCustomerOrderCommand, CustomerOrder>
{
    private readonly ICustomerOrderRepository _customerOrderRepository;

    public DeliveredCustomerOrderCommandHandler(ICustomerOrderRepository customerOrderRepository)
    {
        _customerOrderRepository = customerOrderRepository;
    }

    public async Task<CustomerOrder> Handle(DeliveredCustomerOrderCommand request, CancellationToken cancellationToken)
    {
        var customerOrder = await _customerOrderRepository.GetCustomerOrderByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException($"Not found customer order id {request.Id}");

        customerOrder.MarkOrderAsDelivered();

        _customerOrderRepository.Update(customerOrder);

        await _customerOrderRepository.CommitAsync(cancellationToken);

        return customerOrder;
    }
}
