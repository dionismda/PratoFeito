namespace _Shared.ValueObjects.Restaurants;

public sealed class RestaurantOrderLineItem : ValueObject<RestaurantOrderLineItem>
{
    public Identifier MenuItemId { get; private set; }
    public string Name { get; private set; }
    public int Quantity { get; private set; }

    public RestaurantOrderLineItem(Identifier menuItemId, string name, int quantity)
    {
        MenuItemId = menuItemId;
        Name = name;
        Quantity = quantity;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return MenuItemId;
        yield return Name;
        yield return Quantity;
    }
}
