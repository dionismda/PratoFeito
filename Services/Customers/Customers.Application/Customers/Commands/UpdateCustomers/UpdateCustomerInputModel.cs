namespace Customers.Application.Customers.Commands.UpdateCustomers;

public class UpdateCustomerInputModel
{
    [FromRoute(Name = "id")]
    public Guid Id { get; set; }

    [FromBody]
    public CustomerInputModel Body { get; set; } = null!;
}
