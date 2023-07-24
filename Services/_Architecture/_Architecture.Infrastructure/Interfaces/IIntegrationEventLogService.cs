namespace _Architecture.Infrastructure.Interfaces;

public interface IIntegrationEventLogService
{
    Task<IEnumerable<IntegrationEventLog>> RetrieveEventLogsPendingToPublishAsync(Guid transactionId);
    Task SaveEventAsync(IntegrationEvent @event);
    Task MarkEventAsPublishedAsync(Guid eventId);
    Task MarkEventAsInProgressAsync(Guid eventId);
    Task MarkEventAsFailedAsync(Guid eventId);
}
