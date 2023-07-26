namespace Ordering.Domain.Orders.Events;

public record OrderVerifiedByRestaurantDomainEvent(Identifier OrderId, Identifier RestaurantId) : DomainEvent;
