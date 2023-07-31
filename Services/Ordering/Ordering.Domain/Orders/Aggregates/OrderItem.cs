namespace Ordering.Domain.Orders.Aggregates;

public sealed class OrderItem : Entity, IValidation
{
    public string MenuItemId { get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;
    public int Quantity { get; private set; }
    public Money Price { get; private set; } = null!;
    public Money Total => Price.Multiply(Quantity);

    private OrderItem() : base() { }

    public OrderItem(string menuItemId, string name, int quantity, Money price) : this()
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
