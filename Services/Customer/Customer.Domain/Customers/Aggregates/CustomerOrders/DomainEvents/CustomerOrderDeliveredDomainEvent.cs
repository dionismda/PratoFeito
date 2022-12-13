namespace Customer.Domain.Customers.Aggregates.CustomerOrders.DomainEvents;

public record CustomerOrderDeliveredDomainEvent : DomainEvent
{
    public Guid CustomerId { get; private set; }
    public Guid CustomerOrderId { get; private set; }

    public CustomerOrderDeliveredDomainEvent(Guid customerId, Guid customerOrderId)
    {
        CustomerId = customerId;
        CustomerOrderId = customerOrderId;
    }
}
