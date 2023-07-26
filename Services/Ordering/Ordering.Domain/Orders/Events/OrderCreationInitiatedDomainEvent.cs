namespace Ordering.Domain.Orders.Events;

public record OrderCreationInitiatedDomainEvent(OrderDetails OrderDetails) : DomainEvent;
