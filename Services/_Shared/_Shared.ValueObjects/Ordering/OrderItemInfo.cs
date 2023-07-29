namespace _Shared.ValueObjects.Ordering;

public class OrderItemInfo : ValueObject<OrderItemInfo>
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

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return MenuItemId;
        yield return Quantity;
        yield return Total;
    }
}
