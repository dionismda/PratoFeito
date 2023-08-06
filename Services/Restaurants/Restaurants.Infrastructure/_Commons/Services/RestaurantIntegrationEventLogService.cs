namespace Restaurants.Infrastructure._Commons.Services;

public sealed class RestaurantIntegrationEventLogService : IntegrationEventLogService, IRestaurantIntegrationEventLogService
{
    public RestaurantIntegrationEventLogService(RestaurantContext context) : base(context)
    {
    }
}
