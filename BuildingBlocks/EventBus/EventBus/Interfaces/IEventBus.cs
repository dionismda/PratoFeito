namespace EventBus.Interfaces;

public interface IEventBus
{
    Task PublishAsync(IntegrationEvent @integrationEvent);

    Task SubscribeAsync<TIntegrationEvent, TIntegrationEventHandler>()
        where TIntegrationEvent : IntegrationEvent
        where TIntegrationEventHandler : IIntegrationEventHandler<TIntegrationEvent>;

    Task UnsubscribeAsync<TIntegrationEvent, TIntegrationEventHandler>()
        where TIntegrationEventHandler : IIntegrationEventHandler<TIntegrationEvent>
        where TIntegrationEvent : IntegrationEvent;
}
