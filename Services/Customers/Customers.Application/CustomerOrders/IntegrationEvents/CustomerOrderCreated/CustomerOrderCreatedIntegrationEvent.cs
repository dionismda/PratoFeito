namespace Customers.Application.CustomerOrders.IntegrationEvents.CustomerOrderCreated;

public record CustomerOrderCreatedIntegrationEvent
    (Identifier CustomerOrderId, Identifier CustomerId, Money OrderTotal) : IntegrationEvent;