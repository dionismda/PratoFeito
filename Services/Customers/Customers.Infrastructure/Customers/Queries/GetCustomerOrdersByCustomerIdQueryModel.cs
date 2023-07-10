namespace Customers.Infrastructure.Customers.Queries;

public sealed class GetCustomerOrdersByCustomerIdQueryModel
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public CustomerOrderState State { get; set; }
    public decimal OrderTotal { get; set; }
}
