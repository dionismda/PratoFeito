namespace Restaurants.Infrastructure.Restaurants;

public sealed class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
{
    public RestaurantRepository(RestaurantContext context) : base(context)
    {
    }
}
