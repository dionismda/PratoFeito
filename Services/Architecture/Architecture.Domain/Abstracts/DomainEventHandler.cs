namespace Architecture.Domain.Abstracts;

public abstract class DomainEventHandler<TDomainEventNotification> :
    IDomainEventHandler<TDomainEventNotification>,
    INotificationHandler<TDomainEventNotification>
    where TDomainEventNotification : DomainEvent
{
    public async Task Handle(TDomainEventNotification notification, CancellationToken cancellationToken)
    {
        await HandleAsync(notification);
    }

    public abstract Task HandleAsync(TDomainEventNotification domainEvent);
}
