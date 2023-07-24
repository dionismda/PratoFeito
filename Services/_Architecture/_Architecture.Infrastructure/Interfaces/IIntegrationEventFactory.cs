namespace _Architecture.Infrastructure.Interfaces;

public interface IIntegrationEventFactory
{
    IntegrationEvent? Create(IntegrationEventLog integrationEvent);
}
