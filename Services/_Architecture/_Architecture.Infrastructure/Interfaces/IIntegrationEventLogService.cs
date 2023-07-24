namespace _Architecture.Infrastructure.Interfaces;

public interface IIntegrationEventLogService
{
    Task<IEnumerable<IntegrationEventLog>> GetAllIntegrationEventLogNotPublishedAsync(CancellationToken cancellationToken);
    Task MarkEventAsPublishedAsync(Guid eventId);
    Task MarkEventAsInProgressAsync(Guid eventId);
    Task MarkEventAsFailedAsync(Guid eventId);
}
