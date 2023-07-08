namespace _Architecture.Domain.Interfaces;

public interface IDomainEventHandler<in TDomainEvent>
    where TDomainEvent : DomainEvent
{
    Task HandleAsync(TDomainEvent domainEvent);
}
