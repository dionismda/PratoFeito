namespace Customer.Domain.Aggregates.CustomersAggregate.DomainEvents;

public record CustomerOrderCreateDomainEvent : CustomerDomainEvent
{
    public MoneyValueObject OrderTotal { get; private set; }
    public Guid CustomerOrderId { get; private set; }

    public CustomerOrderCreateDomainEvent(MoneyValueObject orderTotal, Guid customerOrderId, Guid customerId) : base(customerId)
    {
        OrderTotal = orderTotal;
        CustomerOrderId = customerOrderId;
    }
}
