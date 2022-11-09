namespace Customer.Domain.Aggregates.CustomersAggregate.DomainEvents;

public abstract record CustomerOrderDomainEvent : DomainEvent
{
    public long CustomerOrderId { get; private set; }

    protected CustomerOrderDomainEvent(long customerOrderId)
    {
        CustomerOrderId = customerOrderId;
    }
}
