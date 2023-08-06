﻿global using _Architecture.Infrastructure.Abstractions;
global using _Architecture.Infrastructure.BackgroundServices;
global using _Architecture.Infrastructure.Enums;
global using _Architecture.Infrastructure.Extensions;
global using _Architecture.Infrastructure.Interceptors;
global using _Architecture.Infrastructure.Interfaces;
global using _Architecture.Infrastructure.Services;
global using Amazon.SimpleNotificationService;
global using Amazon.SQS;
global using AwsConfiguration.Interfaces;
global using EventBus.Abstractions;
global using EventBus.Interfaces;
global using EventBusAws;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Restaurants.Domain.RestaurantOrders.Aggregates.RestaurantOrderItems.Entities;
global using Restaurants.Domain.RestaurantOrders.Entities;
global using Restaurants.Domain.RestaurantOrders.Interfaces;
global using Restaurants.Domain.Restaurants.Aggregates.MenuItems.Entities;
global using Restaurants.Domain.Restaurants.Aggregates.RestaurantMenus.Entities;
global using Restaurants.Domain.Restaurants.Entities;
global using Restaurants.Domain.Restaurants.Interfaces;
global using Restaurants.Infrastructure._Commons.BackgroundServices;
global using Restaurants.Infrastructure._Commons.EventBus;
global using Restaurants.Infrastructure._Commons.Interfaces;
global using Restaurants.Infrastructure._Commons.Persistences;
global using Restaurants.Infrastructure._Commons.Services;
global using Restaurants.Infrastructure.RestaurantOrders;
global using Restaurants.Infrastructure.Restaurants;
