namespace _Architecture.Infrastructure.BackgroundServices;

public abstract class IntegrationEventLogBackgroundService : IJob
{
    private readonly IIntegrationEventLogService _integrationEventLogService;
    private readonly IIntegrationEventMapper _integrationEventMapper;
    private readonly IEventBusAws _eventBusAws;

    protected IntegrationEventLogBackgroundService(
        IIntegrationEventLogService integrationEventLogService,
        IEventBusAws eventBusAws,
        IIntegrationEventMapper integrationEventMapper)
    {
        _integrationEventLogService = integrationEventLogService;
        _eventBusAws = eventBusAws;
        _integrationEventMapper = integrationEventMapper;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        using (new EventBusLog(nameof(IntegrationEventLogBackgroundService), "Execute").CreateLog())
        {
            var integrationEvenLogs = await _integrationEventLogService.GetAllIntegrationEventLogNotPublishedAsync(default);

            if (integrationEvenLogs.Any())
            {
                foreach (var integrationEvent in integrationEvenLogs)
                {
                    try
                    {
                        await _integrationEventLogService.MarkEventAsInProgressAsync(integrationEvent.EventId);

                        await PublishIntegrationEventAsync(integrationEvent);

                        await _integrationEventLogService.MarkEventAsPublishedAsync(integrationEvent.EventId);
                    }
                    catch
                    {
                        await _integrationEventLogService.MarkEventAsFailedAsync(integrationEvent.EventId);
                    }
                }
            }
        }
    }

    private async Task PublishIntegrationEventAsync(IntegrationEventLog integrationEvent)
    {
        var @event = _integrationEventMapper.Factory.Create(integrationEvent);

        if (@event != null)
            await _eventBusAws.PublishAsync(@event);
    }
}
