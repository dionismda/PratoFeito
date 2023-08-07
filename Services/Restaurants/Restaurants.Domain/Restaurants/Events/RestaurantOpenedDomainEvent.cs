namespace Restaurants.Domain.Restaurants.Events;

public record RestaurantOpenedDomainEvent(Identifier RestaurantId) : DomainEvent;