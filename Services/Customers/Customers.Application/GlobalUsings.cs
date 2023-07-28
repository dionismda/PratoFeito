﻿global using _Architecture.Application.Abstractions;
global using _Architecture.Application.Interfaces;
global using _Architecture.Domain.Exceptions;
global using AutoMapper;
global using Customers.Application._Commons.EventMappers;
global using Customers.Application.CustomerOrders.IntegrationEvents.CustomerOrderCreated;
global using Customers.Application.Customers._Commons;
global using Customers.Domain._Commons.Enums;
global using Customers.Domain.CustomerOrders.Entities;
global using Customers.Domain.CustomerOrders.Events;
global using Customers.Domain.CustomerOrders.Interfaces;
global using Customers.Domain.Customers.Entities;
global using Customers.Domain.Customers.Interfaces;
global using Customers.Infrastructure._Commons.Interfaces;
global using Customers.Infrastructure.Customers;
global using Customers.Infrastructure.Customers.Queries;
global using EventBus.Events;
global using EventBus.Interfaces;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.Extensions.DependencyInjection;
global using System.Reflection;
global using _Shared.ValueObjects._Commons;