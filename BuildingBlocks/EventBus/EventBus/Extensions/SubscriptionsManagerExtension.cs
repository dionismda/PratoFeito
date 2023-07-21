namespace EventBus.Extensions;

public static class SubscriptionsManagerExtension
{
    public static IServiceCollection AddInMemoryEventBusSubscriptionsManager(this IServiceCollection services)
    {
        return services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();
    }
}
