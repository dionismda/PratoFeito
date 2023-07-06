namespace Customers.Application.CustomerOrders.Commands;

public sealed class MarkCustomerOrderAsDeliveredCommand : ICommand<bool>
{
    public Identifier CustomerOrderId { get; private set; } = null!;

    public MarkCustomerOrderAsDeliveredCommand() { }

    public MarkCustomerOrderAsDeliveredCommand(Identifier customerOrderId)
    {
        CustomerOrderId = customerOrderId;
    }
}
