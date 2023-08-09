namespace Restaurants.Application.Restaurants.Commands.CreateRestaurants;

public sealed class CreateRestaurantCommand : RestaurantCommand
{
    private CreateRestaurantCommand() : base() { }

    public CreateRestaurantCommand(string name) : base(name)
    {
    }
}
