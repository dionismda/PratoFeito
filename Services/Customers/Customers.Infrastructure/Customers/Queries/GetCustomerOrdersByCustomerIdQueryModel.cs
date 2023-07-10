namespace Customers.Infrastructure.Customers.Queries;

public sealed class GetCustomerOrdersByCustomerIdQueryModel
{
    public Guid Id { get; set; }
    public Guid Customer_Id { get; set; }
    public CustomerOrderState State { get; set; }
    public decimal Order_Total { get; set; }
}