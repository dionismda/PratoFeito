namespace Restaurants.Infrastructure._Commons.Interceptors;

public class RestaurantEventsInterceptor : EventsInterceptor
{
    public RestaurantEventsInterceptor(IMediator mediator, IRestaurantIntegrationEventMapper mapper) : base(mediator, mapper)
    {
    }
}
