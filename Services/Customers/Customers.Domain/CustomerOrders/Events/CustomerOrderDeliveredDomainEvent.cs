namespace Customers.Domain.CustomerOrders.Events;

public record CustomerOrderDeliveredDomainEvent
    (Identifier CustomerOrderId) : DomainEvent;
