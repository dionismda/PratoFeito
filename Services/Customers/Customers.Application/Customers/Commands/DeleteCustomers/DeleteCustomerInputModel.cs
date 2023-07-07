namespace Customers.Application.Customers.Commands.DeleteCustomers;

public class DeleteCustomerInputModel
{
    [FromRoute(Name = "id")]
    public Guid Id { get; set; }
}