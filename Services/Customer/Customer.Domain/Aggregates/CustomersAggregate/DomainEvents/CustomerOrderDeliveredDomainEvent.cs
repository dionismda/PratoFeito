namespace Customer.Domain.Aggregates.CustomersAggregate.DomainEvents;

public record CustomerOrderDeliveredDomainEvent : CustomerOrderDomainEvent
{
    public Guid CustomerId { get; private set; }

    public CustomerOrderDeliveredDomainEvent(Guid customerId, Guid customerOrderId) : base(customerOrderId)
    {
        CustomerId = customerId;
    }
}
