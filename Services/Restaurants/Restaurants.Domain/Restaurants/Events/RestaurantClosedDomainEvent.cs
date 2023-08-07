namespace Restaurants.Domain.Restaurants.Events;

public record RestaurantClosedDomainEvent(Identifier RestaurantId) : DomainEvent;