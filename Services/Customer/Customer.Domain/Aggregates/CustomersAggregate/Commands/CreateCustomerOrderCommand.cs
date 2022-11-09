namespace Customer.Domain.Aggregates.CustomersAggregate.Commands;

public class CreateCustomerOrderCommand
{
    public long CustomerOrderId { get; private set; }
    public MoneyValueObject OrderTotal { get; private set; }

    public CreateCustomerOrderCommand(long customerOrderId, MoneyValueObject orderTotal)
    {
        CustomerOrderId = customerOrderId;
        OrderTotal = orderTotal;
    }
}
