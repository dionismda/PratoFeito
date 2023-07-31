namespace Restaurants.Domain.RestaurantOrders.Aggregates.RestaurantOrderItems.Entities;

public sealed class RestaurantOrderItem : Entity, IValidation
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

    public void Validate()
    {
        RestaurantOrderItemValidator validator = new();

        var result = validator.Validate(this);

        if (!result.IsValid)
            throw new ValidationDomainException(result.GetErrors());
    }
}
