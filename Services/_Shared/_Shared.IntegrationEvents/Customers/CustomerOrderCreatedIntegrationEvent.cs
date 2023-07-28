namespace _Shared.IntegrationEvents.Customers;

public record CustomerOrderCreatedIntegrationEvent
    (Identifier CustomerOrderId, Identifier CustomerId, Money OrderTotal) : IntegrationEvent;