namespace Customers.Application.CustomersOrders.Commands;

public sealed class CanceledCustomerOrderCommand : ICommand<CustomerOrder>
{
    public Identifier Id { get; private set; } = null!;

    public CanceledCustomerOrderCommand()
    {
    }

    public CanceledCustomerOrderCommand(Identifier id)
    {
        Id = id;
    }
}
