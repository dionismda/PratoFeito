namespace _Architecture.Infrastructure.Services;

public abstract class IntegrationEventLogService : IIntegrationEventLogService, IDisposable
{
    private readonly BaseDbContext _context;
    private volatile bool _disposedValue;

    protected IntegrationEventLogService(BaseDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<IntegrationEventLog>> GetAllIntegrationEventLogNotPublishedAsync(CancellationToken cancellationToken)
    {
        return await _context.IntegrationEventLogs
            .Where(e => e.State != EventStateEnum.Published && e.State != EventStateEnum.InProgress)
            .Take(20)
            .ToListAsync(cancellationToken);
    }

    public async Task MarkEventAsFailedAsync(Guid eventId)
    {
       await UpdateEventStatus(eventId, EventStateEnum.PublishedFailed);
    }

    public async Task MarkEventAsInProgressAsync(Guid eventId)
    {
        await UpdateEventStatus(eventId, EventStateEnum.InProgress);
    }

    public async Task MarkEventAsPublishedAsync(Guid eventId)
    {
        await UpdateEventStatus(eventId, EventStateEnum.Published);
    }

    private async Task UpdateEventStatus(Guid eventId, EventStateEnum status)
    {
        var eventLogEntry = await _context.IntegrationEventLogs.SingleAsync(ie => ie.EventId == eventId);
        eventLogEntry.ChangeStatus(status);

        if (status == EventStateEnum.InProgress)
            eventLogEntry.IncrementTimesSent();

        _context.IntegrationEventLogs.Update(eventLogEntry);

        await _context.SaveChangesAsync();
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