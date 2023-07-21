namespace EventBus.Subscriptions;

public sealed class InMemoryEventBusSubscriptionsManager : IEventBusSubscriptionsManager
{
    private readonly Dictionary<string, List<SubscriptionInfo>> _handlers;
    private readonly List<Type> _eventTypes;
    public event EventHandler<string>? OnEventRemoved;

    public InMemoryEventBusSubscriptionsManager()
    {
        _handlers = new Dictionary<string, List<SubscriptionInfo>>();
        _eventTypes = new List<Type>();
    }

    public bool IsEmpty => _handlers is { Count: 0 };
    public void Clear() => _handlers.Clear();

    public void AddSubscription<TIntegrationEvent, TIIntegrationEventHandler>()
        where TIntegrationEvent : IntegrationEvent
        where TIIntegrationEventHandler : IIntegrationEventHandler<TIntegrationEvent>
    {
        var eventName = GetEventKey<TIntegrationEvent>();

        DoAddSubscription(typeof(TIIntegrationEventHandler), eventName);

        if (!_eventTypes.Contains(typeof(TIntegrationEvent)))
        {
            _eventTypes.Add(typeof(TIntegrationEvent));
        }
    }

    private void DoAddSubscription(Type handlerType, string eventName)
    {
        if (!HasSubscriptionsForEvent(eventName))
        {
            _handlers.Add(eventName, new List<SubscriptionInfo>());
        }

        if (_handlers[eventName].Exists(s => s.HandlerType == handlerType))
        {
            throw new ArgumentException(
                $"Handler Type {handlerType.Name} already registered for '{eventName}'", nameof(handlerType));
        }

        _handlers[eventName].Add(SubscriptionInfo.Typed(handlerType));
    }

    public void RemoveSubscription<TIntegrationEvent, TIIntegrationEventHandler>()
        where TIntegrationEvent : IntegrationEvent
        where TIIntegrationEventHandler : IIntegrationEventHandler<TIntegrationEvent>
    {
        var handlerToRemove = FindSubscriptionToRemove<TIntegrationEvent, TIIntegrationEventHandler>();
        var eventName = GetEventKey<TIntegrationEvent>();
        DoRemoveHandler(eventName, handlerToRemove);
    }

    private SubscriptionInfo? FindSubscriptionToRemove<TIntegrationEvent, TIIntegrationEventHandler>()
            where TIntegrationEvent : IntegrationEvent
            where TIIntegrationEventHandler : IIntegrationEventHandler<TIntegrationEvent>
    {
        var eventName = GetEventKey<TIntegrationEvent>();
        return DoFindSubscriptionToRemove(eventName, typeof(TIIntegrationEventHandler));
    }

    private SubscriptionInfo? DoFindSubscriptionToRemove(string eventName, Type handlerType)
    {
        if (!HasSubscriptionsForEvent(eventName))
        {
            return null;
        }

        return _handlers[eventName].SingleOrDefault(s => s.HandlerType == handlerType);
    }

    private void DoRemoveHandler(string eventName, SubscriptionInfo subsToRemove)
    {
        if (subsToRemove != null)
        {
            _handlers[eventName].Remove(subsToRemove);
            if (!_handlers[eventName].Any())
            {
                _handlers.Remove(eventName);
                var eventType = _eventTypes.SingleOrDefault(e => e.Name == eventName);
                if (eventType != null)
                {
                    _eventTypes.Remove(eventType);
                }

                RaiseOnEventRemoved(eventName);
            }

        }
    }

    private void RaiseOnEventRemoved(string eventName)
    {
        var handler = OnEventRemoved;
        handler?.Invoke(this, eventName);
    }

    public string GetEventKey<TIntegrationEvent>()
    {
        return typeof(TIntegrationEvent).Name.Replace(nameof(IntegrationEvent), "");
    }

    public Type? GetEventTypeByName(string eventName)
    {
        return _eventTypes.SingleOrDefault(t => t.Name == eventName);
    }

    public IEnumerable<SubscriptionInfo> GetHandlersForEvent<TIntegrationEvent>()
        where TIntegrationEvent : IntegrationEvent
    {
        var key = GetEventKey<TIntegrationEvent>();
        return GetHandlersForEvent(key);
    }

    public IEnumerable<SubscriptionInfo> GetHandlersForEvent(string eventName)
    {
        return _handlers[eventName];
    }

    public bool HasSubscriptionsForEvent<TIntegrationEvent>()
        where TIntegrationEvent : IntegrationEvent
    {
        var key = GetEventKey<TIntegrationEvent>();
        return HasSubscriptionsForEvent(key);
    }

    public bool HasSubscriptionsForEvent(string eventName)
    {
        return _handlers.ContainsKey(eventName);
    }
}
