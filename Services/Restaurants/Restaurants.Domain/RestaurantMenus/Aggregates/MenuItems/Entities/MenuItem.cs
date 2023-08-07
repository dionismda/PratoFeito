namespace Restaurants.Domain.RestaurantMenus.Aggregates.MenuItems.Entities;

public sealed class MenuItem : Entity
{
    public string Name { get; private set; }
    public Identifier RestaurantMenuId { get; private set; }
    public Money Price { get; private set; }

    public MenuItem(string name, Money price, Identifier restaurantMenuId)
    {
        Name = name;
        Price = price;
        RestaurantMenuId = restaurantMenuId;
    }
}
