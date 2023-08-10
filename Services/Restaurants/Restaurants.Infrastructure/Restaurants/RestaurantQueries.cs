namespace Restaurants.Infrastructure.Restaurants;

public sealed class RestaurantQueries : DapperQueries, IRestaurantQueries
{
    private readonly string _restaurantSchema;

    public RestaurantQueries(IConnectionDapper connectionDapper) : base(connectionDapper)
    {
        _restaurantSchema = nameof(ContextEnum.Restaurants).ToLower();
    }

    public async Task<IList<GetRestaurantsQueryModel>> GetRestaurantsAsync(CancellationToken cancellationToken)
    {
        using var connection = await ConnectionDapper.GetConnectionAsync(_restaurantSchema);

        var sql = @"SELECT
                        restaurant_id as id,
                        name,
                        state
                    FROM
                        restaurants
                   ";

        var results = await connection.QueryAsync<GetRestaurantsQueryModel>(sql);

        return results.ToList();
    }

    public async Task<GetRestaurantByIdQueryModel?> GetRestaurantByIdAsync(Identifier RestaurantId, CancellationToken cancellationToken)
    {
        using var connection = await ConnectionDapper.GetConnectionAsync(_restaurantSchema);

        var sql = @"SELECT
                        restaurant_id as id,
                        name,
                        state
                    FROM
                        restaurants
                    WHERE
                        restaurant_id = @restaurant_id
                   ";

        return await connection.QueryFirstOrDefaultAsync<GetRestaurantByIdQueryModel>(sql, new { restaurant_id = RestaurantId.Id });
    }
}
