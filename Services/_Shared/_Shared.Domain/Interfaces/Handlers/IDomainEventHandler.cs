namespace _Shared.Domain.Interfaces.Handlers;

public interface IDomainEventHandler<in TDomainEvent> : IHandler 
    where TDomainEvent : DomainEvent
{
    Task HandleAsync(TDomainEvent domainEvent);
}
