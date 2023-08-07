namespace Customers.Application.CustomerOrders.Commands.CancelCustomerOrder;

public class CancelCustomerOrderCommandHandler : ICommandHandler<CancelCustomerOrderCommand, CustomerOrder>
{
    private readonly ICustomerOrderDomainService _customerOrderDomainService;
    private readonly ICustomerOrderRepository _customerOrderRepository;
    public CancelCustomerOrderCommandHandler(ICustomerOrderDomainService customerOrderDomainService, ICustomerOrderRepository customerOrderRepository)
    {
        _customerOrderDomainService = customerOrderDomainService;
        _customerOrderRepository = customerOrderRepository;
    }

    public async Task<CustomerOrder> Handle(CancelCustomerOrderCommand request, CancellationToken cancellationToken)
    {
        var customerOrder = await _customerOrderRepository.GetCustomerOrderByIdAsync(request.Id, cancellationToken);

        if (customerOrder is null)
        {
            throw new NotFoundException($"Not found customer order id {request.Id}");
        }

        customerOrder.MarkOrderAsCanceled();

        await _customerOrderDomainService.UpdateAsync(customerOrder, cancellationToken);

        return customerOrder;
    }
}
