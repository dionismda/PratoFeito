 namespace Ordering.Domain.Orders.Enums;

public enum OrderStateEnum
{
    CREATE_PENDING,
    VERIFIED_BY_CUSTOMER,
    VERIFIED_BY_RESTAURANT,
    PREPARED,
    READY_FOR_DELIVERY,
    DELIVERED,
    REJECTED,
    CANCEL_PENDING,
    CANCELLED
}
