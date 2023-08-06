namespace Restaurants.Infrastructure.Restaurants;

public sealed class RestaurantQueries : DapperQueries, IRestaurantQueries
{
    public RestaurantQueries(IConnectionDapper connectionDapper) : base(connectionDapper)
    {
    }
}
