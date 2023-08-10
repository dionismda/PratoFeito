namespace Restaurants.Application.Restaurants.Commands.CreateRestaurants;

public sealed class CreateRestaurantCommandHandler : ICommandHandler<CreateRestaurantCommand, Restaurant>
{
    private readonly IRestaurantRepository _restaurantRepository;

    public CreateRestaurantCommandHandler(IRestaurantRepository restaurantRepository)
    {
        _restaurantRepository = restaurantRepository;
    }

    public async Task<Restaurant> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = new Restaurant(request.Name);

        _restaurantRepository.Insert(restaurant);

        await _restaurantRepository.CommitAsync(cancellationToken);

        return restaurant;
    }
}
