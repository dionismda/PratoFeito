namespace Customer.Domain.Aggregates.CustomersAggregate.DomainEvents;

public record CustomerOrderRejectedEvent : CustomerOrderDomainEvent
{
    public CustomerOrderRejectedEvent(long customerOrderId) : base(customerOrderId)
    {
    }
}
