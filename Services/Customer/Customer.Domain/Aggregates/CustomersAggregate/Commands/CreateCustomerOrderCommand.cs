namespace Customer.Domain.Aggregates.CustomersAggregate.Commands;

public class CreateCustomerOrderCommand
{
    public Guid CustomerOrderId { get; private set; }
    public MoneyValueObject OrderTotal { get; private set; }

    public CreateCustomerOrderCommand(Guid customerOrderId, MoneyValueObject orderTotal)
    {
        CustomerOrderId = customerOrderId;
        OrderTotal = orderTotal;
    }
}
