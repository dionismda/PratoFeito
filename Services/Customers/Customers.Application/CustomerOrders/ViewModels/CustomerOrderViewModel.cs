namespace Customers.Application.CustomerOrders.ViewModels;

public class CustomerOrderViewModel
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public CustomerOrderState State { get; set; }
    public decimal OrderTotal { get; set; }
}
