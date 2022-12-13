namespace Customer.Domain.Customers.Aggregates.CustomerOrders.Commands;

public class MarkCustomerOrderAsDeliveredCommand : ICommand
{
    public long CustomerOrderId { get; private set; }

    public MarkCustomerOrderAsDeliveredCommand(long customerOrderId)
    {
        CustomerOrderId = customerOrderId;
    }
}
