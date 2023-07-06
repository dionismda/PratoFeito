namespace Customers.Domain.Customers.Events;

public record CustomerOrderLimitUpdatedDomainEvent
    (Money OrderLimit, Identifier CustomerId) : DomainEvent;
