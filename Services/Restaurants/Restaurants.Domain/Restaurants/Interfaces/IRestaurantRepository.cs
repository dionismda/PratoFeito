namespace Restaurants.Domain.Restaurants.Interfaces;

public interface IRestaurantRepository : IGenericRepository<Restaurant>
{
    Task<IList<Restaurant>> GetRestaurantAllAsync(CancellationToken cancellationToken);
    Task<IList<Restaurant>> GetRestaurantDuplicateAsync(Restaurant restaurant, CancellationToken cancellationToken);
    Task<Restaurant?> GetRestaurantByIdAsync(Identifier id, CancellationToken cancellationToken);
}
