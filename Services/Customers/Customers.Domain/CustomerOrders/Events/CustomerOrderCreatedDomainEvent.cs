namespace Customers.Domain.CustomerOrders.Events;

public record CustomerOrderCreatedDomainEvent
    (Identifier CustomerOrderId, Identifier CustomerId, Money OrderTotal) : DomainEvent;
