namespace Restaurants.Application.Restaurants._Commons;

public class RestaurantViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public RestaurantState State { get; set; }
}
