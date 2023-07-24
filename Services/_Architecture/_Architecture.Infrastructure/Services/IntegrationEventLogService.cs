namespace _Architecture.Infrastructure.Services;

public abstract class IntegrationEventLogService : IIntegrationEventLogService, IDisposable
{
    private readonly IntegrationEventLogContext _integrationEventLogContext;
    private readonly List<Type> _eventTypes;
    private volatile bool _disposedValue;

    protected IntegrationEventLogService(IntegrationEventLogContext integrationEventLogContext)
    {
        _integrationEventLogContext = integrationEventLogContext;

        _eventTypes = Assembly.Load(Assembly.GetEntryAssembly().FullName)
            .GetTypes()
            .Where(t => t.Name.EndsWith(nameof(IntegrationEvent)))
            .ToList();
    }

    public async Task<IEnumerable<IntegrationEventLog>> RetrieveEventLogsPendingToPublishAsync(Guid transactionId)
    {
        var result = await _integrationEventLogContext.IntegrationEventLogs
            .Where(e => e.TransactionId == transactionId.ToString() && e.State == EventStateEnum.NotPublished)
            .ToListAsync();

        if (result.Any())
        {
            return result.OrderBy(o => o.CreationTime)
                .Select(e => e.DeserializeJsonContent(_eventTypes.Find(t => t.Name == e.EventTypeShortName)));
        }

        return Enumerable.Empty<IntegrationEventLog>();
    }

    public Task SaveEventAsync(IntegrationEvent @event)
    {
        var eventLogEntry = new IntegrationEventLog(@event);

        _integrationEventLogContext.IntegrationEventLogs.Add(eventLogEntry);

        return _integrationEventLogContext.SaveChangesAsync();
    }

    public Task MarkEventAsFailedAsync(Guid eventId)
    {
        return UpdateEventStatus(eventId, EventStateEnum.PublishedFailed);
    }

    public Task MarkEventAsInProgressAsync(Guid eventId)
    {
        return UpdateEventStatus(eventId, EventStateEnum.InProgress);
    }

    public Task MarkEventAsPublishedAsync(Guid eventId)
    {
        return UpdateEventStatus(eventId, EventStateEnum.Published);
    }

    private Task UpdateEventStatus(Guid eventId, EventStateEnum status)
    {
        var eventLogEntry = _integrationEventLogContext.IntegrationEventLogs.Single(ie => ie.EventId == eventId);
        eventLogEntry.ChangeStatus(status);

        if (status == EventStateEnum.InProgress)
            eventLogEntry.IncrementTimesSent();

        _integrationEventLogContext.IntegrationEventLogs.Update(eventLogEntry);

        return _integrationEventLogContext.SaveChangesAsync();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                _integrationEventLogContext?.Dispose();
            }

            _disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}