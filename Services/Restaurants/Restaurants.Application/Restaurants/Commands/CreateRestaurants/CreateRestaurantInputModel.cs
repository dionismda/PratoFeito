namespace Restaurants.Application.Restaurants.Commands.CreateRestaurants;

public sealed class CreateRestaurantInputModel
{
    [FromBody]
    public RestaurantInputModel Body { get; set; } = null!;
}
