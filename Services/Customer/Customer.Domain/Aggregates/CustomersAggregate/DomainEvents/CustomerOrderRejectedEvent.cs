namespace Customer.Domain.Aggregates.CustomersAggregate.DomainEvents;

public record CustomerOrderRejectedEvent : CustomerOrderDomainEvent
{
    public CustomerOrderRejectedEvent(Guid customerOrderId) : base(customerOrderId)
    {
    }
}
