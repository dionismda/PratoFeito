namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurants;

public sealed class UpdateRestaurantCommand : RestaurantCommand
{
    public Identifier Id { get; private set; } = null!;

    private UpdateRestaurantCommand() : base() { }

    public UpdateRestaurantCommand(Identifier id, string name) : base(name)
    {
        Id = id;
    }
}
