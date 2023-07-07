namespace Customers.Application.Customers._Commons;

public class CustomerInputModel
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}