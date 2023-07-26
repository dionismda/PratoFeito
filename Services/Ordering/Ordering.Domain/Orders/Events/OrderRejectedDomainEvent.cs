namespace Ordering.Domain.Orders.Events;

public record OrderRejectedDomainEvent(Identifier OrderId) : DomainEvent;
