namespace Restaurants.Domain.Restaurants.Exceptions;

public class RestaurantStateNotOpenedException : Exception
{
    public RestaurantStateNotOpenedException() : base($"The current state is not Opened")
    { }
}