namespace Restaurants.Domain.Restaurants.Extensions;

public static class RestaurantLinqExtension
{
    public static bool HasName(this IEnumerable<Restaurant> restaurants, string name)
    {
        return restaurants.Any(x => x.Name.Equals(name));
    }
}