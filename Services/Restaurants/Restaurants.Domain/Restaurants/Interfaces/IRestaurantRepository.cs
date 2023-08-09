namespace Restaurants.Domain.Restaurants.Interfaces;

public interface IRestaurantRepository : IGenericRepository<Restaurant>
{
    Task<Restaurant?> GetRestaurantByIdAsync(Identifier id, CancellationToken cancellationToken);

    Task<bool> IsRestaurantUnique(string name, CancellationToken cancellationToken, Identifier? id = null);
}
