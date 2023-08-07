namespace Restaurants.Infrastructure.RestaurantOrders;

public sealed class RestaurantOrderRepository : Repository<RestaurantOrder>, IRestaurantOrderRepository
{
    public RestaurantOrderRepository(RestaurantContext context) : base(context)
    {
    }
}
