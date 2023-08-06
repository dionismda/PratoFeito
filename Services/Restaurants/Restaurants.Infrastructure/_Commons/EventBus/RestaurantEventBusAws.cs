namespace Restaurants.Infrastructure._Commons.EventBus;

public sealed class RestaurantEventBusAws : EventBusAws.EventBusAws, IRestaurantEventBusAws, IDisposable
{
    public RestaurantEventBusAws(
        IEventBusSubscriptionsManager subsManager,
        IPollyPolicy pollyPolicy,
        IAmazonSimpleNotificationService amazonSNS,
        IAmazonSQS amazonSQS) : base(subsManager, pollyPolicy, amazonSNS, amazonSQS)
    {
    }

    public void Dispose()
    {
        SubsManager.Clear();
    }
}
