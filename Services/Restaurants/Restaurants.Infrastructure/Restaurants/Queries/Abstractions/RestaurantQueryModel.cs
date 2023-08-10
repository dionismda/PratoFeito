namespace Restaurants.Infrastructure.Restaurants.Queries.Abstractions;

public abstract class RestaurantQueryModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public RestaurantState State { get; set; }
}