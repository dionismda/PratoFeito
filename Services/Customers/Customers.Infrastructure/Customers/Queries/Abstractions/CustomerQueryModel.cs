namespace Customers.Infrastructure.Customers.Queries.Abstractions;

public abstract class CustomerQueryModel
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public decimal Order_limit { get; set; }
}
