namespace Customers.Application.CustomerOrders.Commands;

public sealed class CustomerOrderCreatedCommand : ICommand<CustomerOrder>
{
    public Identifier CustomerOrderId { get; private set; } = null!;
    public Identifier CustomerId { get; private set; } = null!;
    public Money OrderTotal { get; private set; } = null!;

    public CustomerOrderCreatedCommand() { }

    public CustomerOrderCreatedCommand(Identifier customerOrderId, Identifier customerId, Money orderTotal)
    {
        CustomerOrderId = customerOrderId;
        CustomerId = customerId;
        OrderTotal = orderTotal;
    }
}
