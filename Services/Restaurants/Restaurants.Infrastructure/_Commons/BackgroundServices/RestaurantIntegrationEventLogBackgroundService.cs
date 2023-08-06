namespace Restaurants.Infrastructure._Commons.BackgroundServices;

public sealed class RestaurantIntegrationEventLogBackgroundService : IntegrationEventLogBackgroundService
{
    public RestaurantIntegrationEventLogBackgroundService(
        IIntegrationEventLogService integrationEventLogService,
        IEventBusAws eventBusAws,
        IIntegrationEventMapper integrationEventMapper) : base(integrationEventLogService, eventBusAws, integrationEventMapper)
    {
    }
}
