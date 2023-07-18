global using _Architecture.Domain.Exceptions;
global using _Architecture.Domain.Interfaces;
global using _Architecture.Domain.ValueObjects;
global using _Architecture.UnitTests._Commons.Abstracts;
global using _Architecture.UnitTests._Commons.Builders;
global using _Architecture.UnitTests.Application.Extensions;
global using _Architecture.UnitTests.Domain.Extensions;
global using _Architecture.UnitTests.Domain.ValueObjects.Helpers;
global using AutoMapper;
global using Customers.Application.CustomerOrders.Commands.CancelCustomerOrder;
global using Customers.Application.Customers.Commands.CreateCustomers;
global using Customers.Application.Customers.Commands.DeleteCustomers;
global using Customers.Application.Customers.Commands.UpdateCustomers;
global using Customers.Application.Customers.Queries.GetCustomerById;
global using Customers.Application.Customers.Queries.GetCustomerOrdersByCustomerId;
global using Customers.Application.Customers.Queries.GetCustomers;
global using Customers.Domain._Commons.Enums;
global using Customers.Domain.CustomerOrders.Entities;
global using Customers.Domain.CustomerOrders.Events;
global using Customers.Domain.CustomerOrders.Exceptions;
global using Customers.Domain.CustomerOrders.Interfaces;
global using Customers.Domain.CustomerOrders.Services;
global using Customers.Domain.CustomerOrders.Specifications;
global using Customers.Domain.Customers.Entities;
global using Customers.Domain.Customers.Events;
global using Customers.Domain.Customers.Interfaces;
global using Customers.Domain.Customers.Services;
global using Customers.Domain.Customers.Specifications;
global using Customers.Infrastructure.Customers;
global using Customers.Infrastructure.Customers.Queries;
global using Customers.UnitTests._Commons.Builders;
global using Customers.UnitTests._Commons.Extensions;
global using Moq;
global using Xunit;
