namespace Ordering.Domain.Orders.Events;

public record OrderVerifiedByCustomerDomainEvent(Identifier OrderId, Identifier CustomerId) : DomainEvent;
