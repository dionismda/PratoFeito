namespace Restaurants.Domain.Restaurants.Aggregates.RestaurantMenus.Entities;

public sealed class RestaurantMenu : Entity, IValidation
{
    public string MenuVersion { get; private set; }

    private List<MenuItem> _menuItems = new();
    public IReadOnlyCollection<MenuItem> MenuItems
    {
        get => _menuItems.AsReadOnly();
        private set => _menuItems = value.ToList();
    }

    public RestaurantMenu(string menuVersion)
    {
        MenuVersion = menuVersion;
    }

    public void AddMenuItem(MenuItem menuItem)
    {
        _menuItems.Add(menuItem);
    }

    public void RemoveOrderItem(MenuItem menuItem)
    {
        _menuItems ??= new List<MenuItem>();

        if (menuItem.Id == default) return;

        var index = _menuItems.FindIndex(x => x.Id == menuItem.Id);

        if (index != -1) _menuItems[index] = menuItem;
    }

    public void RemoveContact(MenuItem menuItem)
    {
        _menuItems.Remove(menuItem);
    }

    public void Validate()
    {
        RestaurantMenuValidator validator = new();

        var result = validator.Validate(this);

        if (!result.IsValid)
            throw new ValidationDomainException(result.GetErrors());
    }
}
