namespace Customer.Domain.Customers.Aggregates.CustomerOrders.Commands;

public class CreateCustomerOrderCommand : ICommand
{
    public Guid CustomerOrderId { get; private set; }
    public MoneyValueObject OrderTotal { get; private set; }

    public CreateCustomerOrderCommand(Guid customerOrderId, MoneyValueObject orderTotal)
    {
        CustomerOrderId = customerOrderId;
        OrderTotal = orderTotal;
    }
}
