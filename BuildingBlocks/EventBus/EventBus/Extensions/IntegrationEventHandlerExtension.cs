namespace EventBus.Extensions;

public static class IntegrationEventHandlerExtension
{
    public static IServiceCollection AddIntegrationEventHandler<TIntegrationEvent, TIntegrationEventHandler>(this IServiceCollection services)
        where TIntegrationEvent : IntegrationEvent
        where TIntegrationEventHandler : class, IIntegrationEventHandler<TIntegrationEvent>
    {
        return services.AddTransient<IIntegrationEventHandler<TIntegrationEvent>, TIntegrationEventHandler>();
    }
}
