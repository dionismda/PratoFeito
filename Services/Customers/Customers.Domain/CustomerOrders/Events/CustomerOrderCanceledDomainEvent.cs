namespace Customers.Domain.CustomerOrders.Events;

public record CustomerOrderCanceledDomainEvent
    (Identifier CustomerOrderId) : DomainEvent;
