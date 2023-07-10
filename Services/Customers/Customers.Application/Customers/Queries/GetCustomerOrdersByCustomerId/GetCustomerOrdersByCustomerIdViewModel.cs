namespace Customers.Application.Customers.Queries.GetCustomerOrdersByCustomerId;

public sealed class GetCustomerOrdersByCustomerIdViewModel
{
    public Guid Id { get; set; }
    public CustomerOrderState State { get; set; }
    public decimal OrderTotal { get; set; }
}
