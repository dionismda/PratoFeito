namespace EventBus.Interfaces;

public interface IEventBus
{
    void Publish(IntegrationEvent @event);

    void Subscribe<TIntegrationEvent, TIntegrationEventHandler>()
        where TIntegrationEvent : IntegrationEvent
        where TIntegrationEventHandler : IIntegrationEventHandler<TIntegrationEvent>;

    void Unsubscribe<TIntegrationEvent, TIntegrationEventHandler>()
        where TIntegrationEventHandler : IIntegrationEventHandler<TIntegrationEvent>
        where TIntegrationEvent : IntegrationEvent;
}
