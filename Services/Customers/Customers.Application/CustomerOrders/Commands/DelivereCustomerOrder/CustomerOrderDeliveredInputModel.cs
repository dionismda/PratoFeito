namespace Customers.Application.CustomerOrders.Commands.DelivereCustomerOrder;

public class CustomerOrderDeliveredInputModel
{
    [FromRoute(Name = "id")]
    public Guid Id { get; set; }
}