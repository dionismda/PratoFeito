namespace Customer.Domain.Aggregates.CustomersAggregate.DomainEvents;

public abstract record CustomerOrderDomainEvent : DomainEvent
{
    public Guid CustomerOrderId { get; private set; }

    protected CustomerOrderDomainEvent(Guid customerOrderId)
    {
        CustomerOrderId = customerOrderId;
    }
}
