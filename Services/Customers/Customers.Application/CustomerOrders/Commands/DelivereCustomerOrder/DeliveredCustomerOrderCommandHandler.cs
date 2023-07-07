namespace Customers.Application.CustomerOrders.Commands.DelivereCustomerOrder;

public class DeliveredCustomerOrderCommandHandler : ICommandHandler<DeliveredCustomerOrderCommand, CustomerOrder>
{
    private readonly ICustomerOrderDomainService _customerOrderDomainService;

    public DeliveredCustomerOrderCommandHandler(ICustomerOrderDomainService customerOrderDomainService)
    {
        _customerOrderDomainService = customerOrderDomainService;
    }

    public async Task<CustomerOrder> Handle(DeliveredCustomerOrderCommand request, CancellationToken cancellationToken)
    {
        var customerOrder = await _customerOrderDomainService.GetByIdAsync(request.Id, cancellationToken);

        if (customerOrder is null)
        {
            //Todo criar expception especifica?
            throw new NotFoundException($"Not found customer order id {request.Id}");
        }

        customerOrder.MarkOrderAsDelivered();

        customerOrder.Validate();

        await _customerOrderDomainService.UpdateAsync(customerOrder, cancellationToken);

        return customerOrder;
    }
}
