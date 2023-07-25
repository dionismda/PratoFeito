namespace Ordering.Domain.Orders.Aggregates;

public sealed class OrderItem : Entity, IValidation
{
    public string MenuItemId { get; private set; }
    public string Name { get; private set; }
    public int Quantity { get; private set; }
    public Money Price { get; private set; }
    public Money Total => Price.Multiply(Quantity);

    public OrderItem(string menuItemId, string name, int quantity, Money price)
    {
        MenuItemId = menuItemId;
        Name = name;
        Quantity = quantity;
        Price = price;
    }

    public void Validate()
    {
        OrderItemValidator validator = new();

        var result = validator.Validate(this);

        if (!result.IsValid)
            throw new ValidationDomainException(result.GetErrors());
    }
}
