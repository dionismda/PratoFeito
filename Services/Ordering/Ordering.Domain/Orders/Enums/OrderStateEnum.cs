 namespace Ordering.Domain.Orders.Enums;

public enum OrderStateEnum
{
    CREATE_PENDING = 0,
    VERIFIED_BY_CUSTOMER = 1,
    VERIFIED_BY_RESTAURANT = 2,
    PREPARED = 3,
    READY_FOR_DELIVERY = 4,
    DELIVERED = 5,
    REJECTED = 6,
    CANCEL_PENDING = 7,
    CANCELLED = 8
}
