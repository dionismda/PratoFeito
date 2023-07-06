namespace Customers.Application.CustomerOrders.Commands.Handlers;

public class DeliveredCustomerOrderCommandHandler : CustomerOrderCommandHandler<DeliveredCustomerOrderCommand, CustomerOrder>
{
    public DeliveredCustomerOrderCommandHandler(ICustomerOrderDomainService domainService) : base(domainService)
    {
    }

    public override async Task<CustomerOrder> Handle(DeliveredCustomerOrderCommand request, CancellationToken cancellationToken)
    {
        var customerOrder = await DomainService.GetCustomerOrderAsync(request.Id, cancellationToken);

        if (customerOrder is null)
        {
            //Todo criar expception especifica?
            throw new NotFoundException($"Not found customer order id {request.Id}");
        }

        customerOrder.MarkOrderAsDelivered();

        customerOrder.Validate();

        await DomainService.UpdateAsync(customerOrder, cancellationToken);

        return customerOrder;
    }
}
