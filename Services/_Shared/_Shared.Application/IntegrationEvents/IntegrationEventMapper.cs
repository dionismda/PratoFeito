namespace _Shared.Application.IntegrationEvents;

public abstract class IntegrationEventMapper : IIntegrationEventMapper
{
    protected IntegrationEventMapper()
    {
        Factory = new IntegrationEventFactory(GetType().Assembly);
    }

    public IIntegrationEventFactory Factory { get; }

    public List<IntegrationEventLogEntity> Map(IEnumerable<DomainEvent> domainEvents)
    {
        var integrationEvents = domainEvents.Select(e => MapDomainEvent(e))
                                            .Where(e => e != null)
                                            .ToList();

        return integrationEvents.Select(e => MapIntegrationEvent(e)).ToList();
    }

    protected abstract IntegrationEvent? MapDomainEvent<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : DomainEvent;

    protected abstract IntegrationEventLogEntity MapIntegrationEvent(IntegrationEvent? integrationEvent);
}
