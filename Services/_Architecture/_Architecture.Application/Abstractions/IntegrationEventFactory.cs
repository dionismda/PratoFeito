namespace _Architecture.Application.Abstractions;

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

    public IntegrationEvent? Create(IntegrationEventLog integrationEvent)
    {
        var eventType = _eventTypes[integrationEvent.EventTypeShortName];
        return integrationEvent.DeserializeIntegrationEvent(eventType);
    }
}
