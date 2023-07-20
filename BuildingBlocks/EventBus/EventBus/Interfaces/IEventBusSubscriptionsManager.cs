namespace EventBus.Interfaces;

public interface IEventBusSubscriptionsManager
{
    event EventHandler<string> OnEventRemoved;
    bool IsEmpty { get; }

    void AddSubscription<TIntegrationEvent, TIIntegrationEventHandler>()
        where TIntegrationEvent : IntegrationEvent
        where TIIntegrationEventHandler : IIntegrationEventHandler<TIntegrationEvent>;

    void RemoveSubscription<TIntegrationEvent, TIIntegrationEventHandler>()
            where TIIntegrationEventHandler : IIntegrationEventHandler<TIntegrationEvent>
            where TIntegrationEvent : IntegrationEvent;

    bool HasSubscriptionsForEvent<TIntegrationEvent>()
        where TIntegrationEvent : IntegrationEvent;

    bool HasSubscriptionsForEvent(string eventName);

    Type GetEventTypeByName(string eventName);

    void Clear();

    IEnumerable<SubscriptionInfo> GetHandlersForEvent<TIntegrationEvent>()
        where TIntegrationEvent : IntegrationEvent;

    IEnumerable<SubscriptionInfo> GetHandlersForEvent(string eventName);

    string GetEventKey<TIntegrationEvent>();
}