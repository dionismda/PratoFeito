namespace Customer.Domain.Customers.Aggregates.CustomerOrders.DomainEvents;

public record CustomerOrderRejectedDomainEvent : DomainEvent
{
    public Guid CustomerOrderId { get; private set; }

    public CustomerOrderRejectedDomainEvent(Guid customerOrderId)
    {
        CustomerOrderId = customerOrderId;
    }
}
