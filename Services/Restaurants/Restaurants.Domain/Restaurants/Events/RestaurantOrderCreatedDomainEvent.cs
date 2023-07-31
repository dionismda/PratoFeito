namespace Restaurants.Domain.Restaurants.Events;

public record RestaurantOrderCreatedDomainEvent
    (RestaurantOrderLineItem RestaurantOrderLine, Identifier RestaurantId) : DomainEvent;