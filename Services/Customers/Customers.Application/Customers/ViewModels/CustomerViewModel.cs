namespace Customers.Application.Customers.ViewModels;

public class CustomerViewModel
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}