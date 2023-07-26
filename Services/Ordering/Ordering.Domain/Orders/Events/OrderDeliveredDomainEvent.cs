namespace Ordering.Domain.Orders.Events;

public record OrderDeliveredDomainEvent(Identifier OrderId) : DomainEvent;
