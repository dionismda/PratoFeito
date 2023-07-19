namespace Customers.Infrastructure.Customers.Queries;

public sealed class GetCustomerByIdQueryModel
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public decimal Order_limit { get; set; }
}
