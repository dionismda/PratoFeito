namespace Customers.Application.CustomerOrders.Commands.DelivereCustomerOrder;

public class DeliveredCustomerOrderCommandHandler : ICommandHandler<DeliveredCustomerOrderCommand, CustomerOrder>
{
    private readonly ICustomerOrderDomainService _customerOrderDomainService;
    private readonly ICustomerOrderRepository _customerOrderRepository;

    public DeliveredCustomerOrderCommandHandler(ICustomerOrderDomainService customerOrderDomainService, ICustomerOrderRepository customerOrderRepository)
    {
        _customerOrderDomainService = customerOrderDomainService;
        _customerOrderRepository = customerOrderRepository;
    }

    public async Task<CustomerOrder> Handle(DeliveredCustomerOrderCommand request, CancellationToken cancellationToken)
    {
        var customerOrder = await _customerOrderRepository.GetCustomerOrderByIdAsync(request.Id, cancellationToken);

        if (customerOrder is null)
        {
            throw new NotFoundException($"Not found customer order id {request.Id}");
        }

        customerOrder.MarkOrderAsDelivered();

        await _customerOrderDomainService.UpdateAsync(customerOrder, cancellationToken);

        return customerOrder;
    }
}
