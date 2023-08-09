namespace Restaurants.Application.Restaurants.Commands.Abstractions;

public abstract class RestaurantCommand : ICommand<Restaurant>
{
    public string Name { get; private set; } = null!;

    protected RestaurantCommand() { }

    protected RestaurantCommand(string name)
    {
        Name = name;
    }
}
