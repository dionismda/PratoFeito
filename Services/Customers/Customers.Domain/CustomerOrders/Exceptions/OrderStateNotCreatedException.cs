namespace Customers.Domain.CustomerOrders.Exceptions;

public class OrderStateNotCreatedException : Exception
{
    public OrderStateNotCreatedException() : base($"The current state is not Created")
    { }
}
