namespace Customer.Domain.Customers.Aggregates.CustomerOrders.DomainEvents;

public record CustomerOrderCreateDomainEvent : DomainEvent
{
    public Guid CustomerId { get; private set; }
    public MoneyValueObject OrderTotal { get; private set; }
    public Guid CustomerOrderId { get; private set; }

    public CustomerOrderCreateDomainEvent(MoneyValueObject orderTotal, Guid customerOrderId, Guid customerId)
    {
        OrderTotal = orderTotal;
        CustomerOrderId = customerOrderId;
        CustomerId = customerId;
    }
}
