namespace Restaurants.Domain.RestaurantOrders.Aggregates.RestaurantOrderItems.Entities;

public sealed class RestaurantOrderItem : Entity
{
    public Identifier MenuItemId { get; private set; }
    public string Name { get; private set; }
    public int Quantity { get; private set; }

    public RestaurantOrderItem(Identifier menuItemId, string name, int quantity)
    {
        MenuItemId = menuItemId;
        Name = name;
        Quantity = quantity;
    }
}
