using _Shared.Domain.Events.Domain;

namespace _Shared.Domain.Interfaces;

public interface IDomainEventHandler<in TDomainEvent> : IHandler where TDomainEvent : DomainEvent
{
    Task HandleAsync(TDomainEvent domainEvent);
}
