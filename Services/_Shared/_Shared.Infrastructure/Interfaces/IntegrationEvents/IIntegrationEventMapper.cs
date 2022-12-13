namespace _Shared.Infrastructure.Interfaces.IntegrationEvents;

public interface IIntegrationEventMapper
{
    public IIntegrationEventFactory Factory { get; }
    List<IntegrationEventLogEntity> Map(IEnumerable<DomainEvent> domainEvents);
}
