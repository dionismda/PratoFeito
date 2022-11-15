namespace Customer.Domain.Aggregates.CustomersAggregate.DomainEvents;

public record CustomerOrderCreateEvent : CustomerDomainEvent
{
    public MoneyValueObject OrderTotal { get; private set; }
    public Guid CustomerOrderId { get; private set; }

    public CustomerOrderCreateEvent(MoneyValueObject orderTotal, Guid customerOrderId, Guid customerId) : base(customerId)
    {
        OrderTotal = orderTotal;
        CustomerOrderId = customerOrderId;
    }
}
