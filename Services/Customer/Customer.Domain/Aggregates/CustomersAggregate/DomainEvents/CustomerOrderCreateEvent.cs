namespace Customer.Domain.Aggregates.CustomersAggregate.DomainEvents;

public record CustomerOrderCreateEvent : CustomerDomainEvent
{
    public MoneyValueObject OrderTotal { get; private set; }
    public long CustomerOrderId { get; private set; }

    public CustomerOrderCreateEvent(MoneyValueObject orderTotal, long customerOrderId, long customerId) : base(customerId)
    {
        OrderTotal = orderTotal;
        CustomerOrderId = customerOrderId;
    }
}
