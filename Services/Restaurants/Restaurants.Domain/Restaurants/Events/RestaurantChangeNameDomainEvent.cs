namespace Restaurants.Domain.Restaurants.Events;

public record RestaurantChangeNameDomainEvent(string RestaurantName) : DomainEvent;
