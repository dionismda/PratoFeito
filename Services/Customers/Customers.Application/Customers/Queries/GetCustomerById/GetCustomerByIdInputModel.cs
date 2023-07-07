namespace Customers.Application.Customers.Queries.GetCustomerById;

public class GetCustomerByIdInputModel
{
    [FromRoute(Name = "id")]
    public Guid Id { get; set; }
}