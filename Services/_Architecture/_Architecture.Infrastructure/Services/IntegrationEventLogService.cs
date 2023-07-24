namespace _Architecture.Infrastructure.Services;

public abstract class IntegrationEventLogService : IIntegrationEventLogService, IDisposable
{
    private readonly BaseDbContext _context;
    private volatile bool _disposedValue;

    protected IntegrationEventLogService(BaseDbContext context)
    {
        _context = context;
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
        var eventLogEntry = _context.IntegrationEventLogs.Single(ie => ie.EventId == eventId);
        eventLogEntry.ChangeStatus(status);

        if (status == EventStateEnum.InProgress)
            eventLogEntry.IncrementTimesSent();

        _context.IntegrationEventLogs.Update(eventLogEntry);

        return _context.SaveChangesAsync();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                _context?.Dispose();
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