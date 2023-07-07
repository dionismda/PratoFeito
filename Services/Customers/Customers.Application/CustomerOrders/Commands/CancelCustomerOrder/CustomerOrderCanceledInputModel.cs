namespace Customers.Application.CustomerOrders.Commands.CancelCustomerOrder;

public class CustomerOrderCanceledInputModel
{
    [FromRoute(Name = "id")]
    public Guid Id { get; set; }
}
