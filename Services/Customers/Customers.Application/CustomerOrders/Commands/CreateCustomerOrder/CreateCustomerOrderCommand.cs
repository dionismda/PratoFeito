namespace Customers.Application.CustomerOrders.Commands.CreateCustomerOrder;

public sealed class CreateCustomerOrderCommand : ICommand<CustomerOrder>
{
    public Identifier CustomerId { get; private set; } = null!;
    public Money OrderTotal { get; private set; } = null!;

    public CreateCustomerOrderCommand() { }

    public CreateCustomerOrderCommand(Identifier customerId, Money orderTotal)
    {
        CustomerId = customerId;
        OrderTotal = orderTotal;
    }
}
