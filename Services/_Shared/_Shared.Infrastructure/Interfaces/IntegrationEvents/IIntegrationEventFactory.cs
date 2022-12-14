namespace _Shared.Infrastructure.Interfaces.IntegrationEvents;

public interface IIntegrationEventFactory
{
    IntegrationEvent Create(IntegrationEventLogEntity integrationEvent);
}
