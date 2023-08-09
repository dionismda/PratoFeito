namespace Restaurants.Infrastructure.RestaurantMenus;

public sealed class RestaurantMenuRepository : Repository<RestaurantMenu>, IRestaurantMenuRepository
{
    public RestaurantMenuRepository(RestaurantContext context) : base(context)
    {
    }
}
