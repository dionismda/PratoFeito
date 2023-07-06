namespace Customers.Application.CustomerOrders.Commands;

public sealed class DeliveredCustomerOrderCommand : ICommand<CustomerOrder>
{
    public Identifier Id { get; private set; } = null!;

    public DeliveredCustomerOrderCommand() { }

    public DeliveredCustomerOrderCommand(Identifier id)
    {
        Id = id;
    }
}
