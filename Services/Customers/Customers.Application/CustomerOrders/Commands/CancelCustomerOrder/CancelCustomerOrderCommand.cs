namespace Customers.Application.CustomerOrders.Commands.CancelCustomerOrder;

public sealed class CancelCustomerOrderCommand : ICommand<CustomerOrder>
{
    public Identifier Id { get; private set; } = null!;

    public CancelCustomerOrderCommand()
    {
    }

    public CancelCustomerOrderCommand(Identifier id)
    {
        Id = id;
    }
}
