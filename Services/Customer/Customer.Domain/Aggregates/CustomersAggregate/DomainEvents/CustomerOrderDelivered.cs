namespace Customer.Domain.Aggregates.CustomersAggregate.DomainEvents;

public record CustomerOrderDelivered : CustomerOrderDomainEvent
{
    public long CustomerId { get; private set; }

    public CustomerOrderDelivered(long customerId, long customerOrderId) : base(customerOrderId)
    {
        CustomerId = customerId;
    }
}
