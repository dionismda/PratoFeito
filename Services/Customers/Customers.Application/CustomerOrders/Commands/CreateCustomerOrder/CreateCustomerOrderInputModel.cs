namespace Customers.Application.CustomerOrders.Commands.CreateCustomerOrder;

public class CreateCustomerOrderInputModel
{
    public Guid CustomerId { get; set; }
    public decimal OrderTotal { get; set; }
}