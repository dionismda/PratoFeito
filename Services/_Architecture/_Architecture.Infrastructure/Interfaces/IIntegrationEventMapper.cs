namespace _Architecture.Infrastructure.Interfaces;

public interface IIntegrationEventMapper
{
    public IIntegrationEventFactory Factory { get; }
    List<IntegrationEventLog> Map(IEnumerable<DomainEvent> domainEvents);
}