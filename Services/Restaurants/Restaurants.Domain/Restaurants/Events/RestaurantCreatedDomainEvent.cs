﻿namespace Restaurants.Domain.Restaurants.Events;

public record RestaurantCreatedDomainEvent
    (string Name) : DomainEvent;