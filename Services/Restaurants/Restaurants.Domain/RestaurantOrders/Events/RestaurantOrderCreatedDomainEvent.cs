namespace Restaurants.Domain.RestaurantOrders.Events;

public record RestaurantOrderCreatedDomainEvent
    (Identifier RestaurantId, IReadOnlyCollection<RestaurantOrderItem> RestaurantOrderLine) : DomainEvent;