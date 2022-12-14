namespace _Shared.Infrastructure.Interfaces;

public interface IDomainMediator
{
    Task Publish<TDomainNotification>(TDomainNotification notification, CancellationToken cancellationToken = default)
        where TDomainNotification : DomainEvent;
}