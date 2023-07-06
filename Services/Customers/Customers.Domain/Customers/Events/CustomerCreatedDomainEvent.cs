namespace Customers.Domain.Customers.Events;

public record CustomerCreatedDomainEvent
    (PersonName Name, Money OrderLimit, Identifier CustomerId) : DomainEvent;