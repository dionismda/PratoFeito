namespace Customers.Application.Customers.Queries.GetCustomerOrdersByCustomerId;

public sealed class GetCustomerOrdersByCustomerIdInputModel
{
    [FromRoute(Name = "id")]
    public Guid Id { get; set; }
}
