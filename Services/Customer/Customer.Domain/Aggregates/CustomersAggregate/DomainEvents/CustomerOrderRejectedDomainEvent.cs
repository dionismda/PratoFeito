namespace Customer.Domain.Aggregates.CustomersAggregate.DomainEvents;

public record CustomerOrderRejectedDomainEvent : CustomerOrderDomainEvent
{
    public CustomerOrderRejectedDomainEvent(Guid customerOrderId) : base(customerOrderId)
    {
    }
}
