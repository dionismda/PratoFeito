namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurants;

public sealed class UpdateRestaurantInputModel
{
    [FromRoute(Name = "id")]
    public Guid Id { get; set; }

    [FromBody]
    public RestaurantInputModel Body { get; set; } = null!;
}
