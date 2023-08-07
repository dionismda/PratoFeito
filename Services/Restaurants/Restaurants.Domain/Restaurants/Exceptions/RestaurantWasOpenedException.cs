namespace Restaurants.Domain.Restaurants.Exceptions;

public class RestaurantWasOpenedException : Exception
{
    public RestaurantWasOpenedException(Identifier restaurantId) : base($"The restarant {restaurantId} was opened")
    { }
}