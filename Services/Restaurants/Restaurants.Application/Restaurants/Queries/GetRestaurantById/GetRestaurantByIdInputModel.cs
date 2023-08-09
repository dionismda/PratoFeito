namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById;

public sealed class GetRestaurantByIdInputModel
{
    [FromRoute(Name = "id")]
    public Guid Id { get; set; }
}
