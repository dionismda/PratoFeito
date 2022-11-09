namespace Customer.Domain.Aggregates.CustomersAggregate.Commands;

public class MarkCustomerOrderAsDeliveredCommand
{
    public long CustomerOrderId { get; private set; }

    public MarkCustomerOrderAsDeliveredCommand(long customerOrderId)
    {
        CustomerOrderId = customerOrderId;
    }
}
