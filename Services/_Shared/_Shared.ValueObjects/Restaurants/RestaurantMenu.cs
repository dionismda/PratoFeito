namespace _Shared.ValueObjects.Restaurants;

public sealed class RestaurantMenu : ValueObject<RestaurantMenu>
{
    public List<MenuItem> Items { get; private set; }
    public string MenuVersion { get; private set; }

    public RestaurantMenu(List<MenuItem> items, string menuVersion)
    {
        Items = items;
        MenuVersion = menuVersion;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Items;
        yield return MenuVersion;
    }
}
