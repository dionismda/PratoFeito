namespace Customer.Domain.Customers.Aggregates.CustomerOrders.Commands;

public class CreateCustomerOrderCommand : ICommand
{
    public Guid CustomerId { get; private set; }
    public MoneyValueObject OrderTotal { get; private set; }

    public CreateCustomerOrderCommand(Guid customerId, MoneyValueObject orderTotal)
    {
        CustomerId = customerId;
        OrderTotal = orderTotal;
    }
}
