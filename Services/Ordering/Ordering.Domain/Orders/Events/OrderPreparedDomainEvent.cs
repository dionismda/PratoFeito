namespace Ordering.Domain.Orders.Events;

public record OrderPreparedDomainEvent(Identifier OrderId) : DomainEvent;
