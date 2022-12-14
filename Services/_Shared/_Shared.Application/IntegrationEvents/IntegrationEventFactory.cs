namespace _Shared.Application.IntegrationEvents;

public class IntegrationEventFactory : IIntegrationEventFactory
{
    private readonly Dictionary<string, Type> _eventTypes;

    public IntegrationEventFactory(Assembly integrationEventAssembly)
    {
        var baseEventType = typeof(IntegrationEvent);
        _eventTypes = integrationEventAssembly
                        .GetTypes()
                        .Where(e => baseEventType.IsAssignableFrom(e))
                        .ToDictionary(e => e.Name);
    }

    public IntegrationEvent? Create(IntegrationEventLogEntity integrationEvent)
    {
        var eventType = _eventTypes[integrationEvent.EventTypeShortName];
        var @event = JsonSerializer.Deserialize(integrationEvent.Content, eventType);
        return @event as IntegrationEvent;
    }
}
