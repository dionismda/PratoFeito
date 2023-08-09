namespace Restaurants.Domain.RestaurantMenus.Entities;

public sealed class RestaurantMenu : AggregateRoot
{
    public Identifier RestaurantId { get; private set; }

    public string MenuVersion { get; private set; }

    private List<MenuItem> _menuItems = new();
    public IReadOnlyCollection<MenuItem> MenuItems
    {
        get => _menuItems.AsReadOnly();
        private set => _menuItems = value.ToList();
    }

    public RestaurantMenu(string menuVersion, Identifier restaurantId)
    {
        MenuVersion = menuVersion;
        RestaurantId = restaurantId;
    }

    public void AddMenuItem(MenuItem menuItem)
    {
        _menuItems.Add(menuItem);
    }

    public void UpdateOrderItem(MenuItem menuItem)
    {
        _menuItems ??= new List<MenuItem>();

        if (menuItem.Id == default) return;

        var index = _menuItems.FindIndex(x => x.Id == menuItem.Id);

        if (index != -1) _menuItems[index] = menuItem;
    }

    public void RemoveOrderItem(MenuItem menuItem)
    {
        _menuItems.Remove(menuItem);
    }
}
