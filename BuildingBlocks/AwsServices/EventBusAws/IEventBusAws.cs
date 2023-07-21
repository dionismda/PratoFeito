namespace EventBusAws;

public interface IEventBusAws : IEventBus
{
    Task CreateTopicAsync<TIntegrationEvent>()
        where TIntegrationEvent : IntegrationEvent;

    Task DeleteTopicAsync<TIntegrationEvent>()
        where TIntegrationEvent : IntegrationEvent;
}
