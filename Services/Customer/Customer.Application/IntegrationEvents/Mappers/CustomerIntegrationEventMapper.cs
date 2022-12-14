namespace Customer.Application.IntegrationEvents.Mappers;

public sealed class CustomerIntegrationEventMapper : IntegrationEventMapper
{
    protected override IntegrationEvent? MapDomainEvent<TDomainEvent>(TDomainEvent domainEvent)
    {
        return null;
    }

    protected override IntegrationEventLogEntity MapIntegrationEvent(IntegrationEvent? integrationEvent)
    {
        return new IntegrationEventLogEntity(integrationEvent);
    }
}
