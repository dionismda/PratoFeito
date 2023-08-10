namespace Restaurants.Application.Restaurants.Queries.GetRestaurants;

public sealed class GetRestaurantsQueryHandler : IQueryHandler<GetRestaurantsQuery, IList<GetRestaurantsQueryModel>>
{
    private readonly IRestaurantQueries _restaurantQueries;

    public GetRestaurantsQueryHandler(IRestaurantQueries restaurantQueries)
    {
        _restaurantQueries = restaurantQueries;
    }

    public async Task<IList<GetRestaurantsQueryModel>> Handle(GetRestaurantsQuery request, CancellationToken cancellationToken)
    {
        return await _restaurantQueries.GetRestaurantsAsync(cancellationToken);
    }
}
