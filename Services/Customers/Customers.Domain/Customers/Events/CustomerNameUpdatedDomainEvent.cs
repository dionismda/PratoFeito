namespace Customers.Domain.Customers.Events;

public record CustomerNameUpdatedDomainEvent
    (PersonName Name, Identifier CustomerId) : DomainEvent;