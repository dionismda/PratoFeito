namespace _Shared.Infrastructure.Mediators;

public class MediaTrMediator : IDomainMediator
{
    private readonly IMediator _mediator;

    public MediaTrMediator(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Task Publish<TDomainNotification>(TDomainNotification notification, CancellationToken cancellationToken = default) 
        where TDomainNotification : DomainEvent
    {
        _mediator.Publish(notification, cancellationToken);
        return Task.CompletedTask;
    }
}
