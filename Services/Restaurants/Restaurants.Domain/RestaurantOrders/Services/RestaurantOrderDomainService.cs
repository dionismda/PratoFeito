namespace Restaurants.Domain.RestaurantOrders.Services;

public class RestaurantOrderDomainService : DomainService<RestaurantOrder>, IRestaurantOrderDomainService
{
    public RestaurantOrderDomainService(IRestaurantOrderRepository restaurantOrderRepository) : base(restaurantOrderRepository)
    {
    }
}
