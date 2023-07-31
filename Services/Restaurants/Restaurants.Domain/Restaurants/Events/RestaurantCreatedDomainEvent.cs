using Restaurants.Domain.Restaurants.Aggregates.RestaurantMenus.Entities;

namespace Restaurants.Domain.Restaurants.Events;

public record RestaurantCreatedDomainEvent
    (string Name, RestaurantMenu Menu) : DomainEvent;