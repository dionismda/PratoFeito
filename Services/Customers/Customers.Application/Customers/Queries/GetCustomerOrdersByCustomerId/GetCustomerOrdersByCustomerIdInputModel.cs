namespace Customers.Application.Customers.Queries.GetCustomerOrdersByCustomerId;

public class GetCustomerOrdersByCustomerIdInputModel
{
    [FromRoute(Name = "id")]
    public Guid Id { get; set; }
}