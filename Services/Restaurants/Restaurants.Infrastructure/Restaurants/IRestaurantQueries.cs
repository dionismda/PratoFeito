namespace Restaurants.Infrastructure.Restaurants;

public interface IRestaurantQueries
{
    Task<IList<GetRestaurantsQueryModel>> GetRestaurantsAsync(CancellationToken cancellationToken);
    Task<GetRestaurantByIdQueryModel?> GetRestaurantByIdAsync(Identifier RestaurantId, CancellationToken cancellationToken);
}