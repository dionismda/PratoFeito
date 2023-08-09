namespace Restaurants.Infrastructure.Restaurants;

public sealed class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
{
    public RestaurantRepository(RestaurantContext context) : base(context)
    {
    }

    public async Task<Restaurant?> GetRestaurantByIdAsync(Identifier id, CancellationToken cancellationToken)
    {
        return await FindByAsync(new GetRestaurantByIdSpecification(id), cancellationToken);
    }

    public async Task<bool> IsRestaurantUnique(string name, CancellationToken cancellationToken, Identifier? id = null)
    {
        var result = await FindAllAsync(new GetRestaurantDuplicate(name, id), cancellationToken);

        return result.Any();
    }
}
