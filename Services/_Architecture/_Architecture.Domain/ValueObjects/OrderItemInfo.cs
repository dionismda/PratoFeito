namespace _Architecture.Domain.ValueObjects;

public class OrderItemInfo : ValueObject<OrderItemInfo>, IValidation
{
    public string MenuItemId { get; private set; }
    public int Quantity { get; private set; }
    public Money Total { get; private set; }

    public OrderItemInfo(string menuItemId, int quantity, Money total)
    {
        MenuItemId = menuItemId;
        Quantity = quantity;
        Total = total;
    }

    public void Validate()
    {
        OrderItemInfoValidator validator = new();

        var result = validator.Validate(this);

        if (!result.IsValid)
            throw new ValidationDomainException(result.GetErrors());
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return MenuItemId;
        yield return Quantity;
        yield return Total;
    }
}
