namespace Ordering.Domain.Orders.Events;

public record OrderReadyForDeliveredDomainEvent(Identifier OrderId) : DomainEvent;
