namespace Customers.Application.Customers.Queries.GetCustomerById;

public sealed class GetCustomerByIdInputModel
{
    [FromRoute(Name = "id")]
    public Guid Id { get; set; }
}