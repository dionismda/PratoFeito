namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById;

public sealed class GetRestaurantByIdQueryHandler : IQueryHandler<GetRestaurantByIdQuery, GetRestaurantByIdQueryModel?>
{
    private readonly IRestaurantQueries _restaurantQueries;

    public GetRestaurantByIdQueryHandler(IRestaurantQueries restaurantQueries)
    {
        _restaurantQueries = restaurantQueries;
    }

    public async Task<GetRestaurantByIdQueryModel?> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        return await _restaurantQueries.GetRestaurantByIdAsync(request.Id, cancellationToken);
    }
}