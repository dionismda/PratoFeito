namespace Customer.Domain.Customers.Aggregates.CustomerOrders.Commands;

public class MarkCustomerOrderAsDeliveredCommand : ICommand
{
    public Guid CustomerOrderId { get; private set; }

    public MarkCustomerOrderAsDeliveredCommand(Guid customerOrderId)
    {
        CustomerOrderId = customerOrderId;
    }
}
