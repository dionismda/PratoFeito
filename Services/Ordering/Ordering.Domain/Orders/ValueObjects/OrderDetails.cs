namespace Ordering.Domain.Orders.ValueObjects;

public sealed class OrderDetails : OrderInfo
{
    public Money OrderTotal { get; private set; }

    public OrderDetails(
        Money orderTotal,
        Identifier customerId,
        Identifier restaurantId,
        List<OrderItem> orderItems) : base(customerId, restaurantId, orderItems)
    {
        OrderTotal = orderTotal;
    }

    public new void Validate()
    {
        OrderDetailsValidator validator = new();

        var result = validator.Validate(this);

        if (!result.IsValid)
            throw new ValidationDomainException(result.GetErrors());
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return CustomerId;
        yield return RestaurantId;
        yield return OrderItems;
        yield return OrderTotal;
    }
}
