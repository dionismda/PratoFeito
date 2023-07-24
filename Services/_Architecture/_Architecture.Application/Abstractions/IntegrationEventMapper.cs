namespace _Architecture.Application.Abstractions;

public abstract class IntegrationEventMapper : IIntegrationEventMapper
{
    protected IntegrationEventMapper()
    {
        Factory = new IntegrationEventFactory(GetType().Assembly);
    }

    public IIntegrationEventFactory Factory { get; }

    public List<IntegrationEventLog> Map(IEnumerable<DomainEvent> domainEvents)
    {
        var integrationEvents = domainEvents.Select(e => MapDomainEvent(e))
                                            .Where(e => e != null)
                                            .ToList();

        return integrationEvents.Select(e => MapIntegrationEvent(e)).ToList();
    }

    public virtual IntegrationEventLog MapIntegrationEvent(IntegrationEvent? integrationEvent)
    {
        return new IntegrationEventLog(integrationEvent);
    }

    protected abstract IntegrationEvent? MapDomainEvent<TDomainEvent>(TDomainEvent domainEvent)
        where TDomainEvent : DomainEvent;
}
