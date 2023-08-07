namespace Restaurants.Infrastructure._Commons.BackgroundServices;

public sealed class RestaurantIntegrationEventLogBackgroundService : IntegrationEventLogBackgroundService
{
    public RestaurantIntegrationEventLogBackgroundService(
        IRestaurantIntegrationEventLogService integrationEventLogService,
        IRestaurantEventBusAws eventBusAws,
        IRestaurantIntegrationEventMapper integrationEventMapper) : base(integrationEventLogService, eventBusAws, integrationEventMapper)
    {
    }
}
