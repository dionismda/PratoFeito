namespace Customers.Application.CustomerOrders.Commands.CancelCustomerOrder;

public class CancelCustomerOrderCommandHandler : ICommandHandler<CancelCustomerOrderCommand, CustomerOrder>
{
    private readonly ICustomerOrderDomainService _customerOrderDomainService;
    public CancelCustomerOrderCommandHandler(ICustomerOrderDomainService customerOrderDomainService)
    {
        _customerOrderDomainService = customerOrderDomainService;
    }

    public async Task<CustomerOrder> Handle(CancelCustomerOrderCommand request, CancellationToken cancellationToken)
    {
        var customerOrder = await _customerOrderDomainService.GetCustomerOrderByIdAsync(request.Id, cancellationToken);

        if (customerOrder is null)
        {
            throw new NotFoundException($"Not found customer order id {request.Id}");
        }

        customerOrder.MarkOrderAsCanceled();

        customerOrder.Validate();

        await _customerOrderDomainService.UpdateAsync(customerOrder, cancellationToken);

        return customerOrder;
    }
}
