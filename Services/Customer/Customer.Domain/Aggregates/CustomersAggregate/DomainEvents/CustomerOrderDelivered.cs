namespace Customer.Domain.Aggregates.CustomersAggregate.DomainEvents;

public record CustomerOrderDelivered : CustomerOrderDomainEvent
{
    public Guid CustomerId { get; private set; }

    public CustomerOrderDelivered(Guid customerId, Guid customerOrderId) : base(customerOrderId)
    {
        CustomerId = customerId;
    }
}
