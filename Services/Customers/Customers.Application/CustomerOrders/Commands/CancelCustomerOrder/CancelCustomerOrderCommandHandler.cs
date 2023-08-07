namespace Customers.Application.CustomerOrders.Commands.CancelCustomerOrder;

public class CancelCustomerOrderCommandHandler : ICommandHandler<CancelCustomerOrderCommand, CustomerOrder>
{
    private readonly ICustomerOrderRepository _customerOrderRepository;
    public CancelCustomerOrderCommandHandler(ICustomerOrderRepository customerOrderRepository)
    {
        _customerOrderRepository = customerOrderRepository;
    }

    public async Task<CustomerOrder> Handle(CancelCustomerOrderCommand request, CancellationToken cancellationToken)
    {
        var customerOrder = await _customerOrderRepository.GetCustomerOrderByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException($"Not found customer order id {request.Id}");

        customerOrder.MarkOrderAsCanceled();

        _customerOrderRepository.Update(customerOrder);

        await _customerOrderRepository.CommitAsync(cancellationToken);

        return customerOrder;
    }
}
