using _Shared.ValueObjects._Commons;

namespace Restaurants.Infrastructure.Restaurants;

public sealed class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
{
    public RestaurantRepository(RestaurantContext context) : base(context)
    {
    }

    public Task<IList<Restaurant>> GetRestaurantAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Restaurant?> GetRestaurantByIdAsync(Identifier id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Restaurant>> GetRestaurantDuplicateAsync(Restaurant restaurant, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
