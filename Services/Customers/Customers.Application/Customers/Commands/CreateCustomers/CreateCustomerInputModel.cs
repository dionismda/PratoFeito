namespace Customers.Application.Customers.Commands.CreateCustomers;

public class CreateCustomerInputModel
{
    [FromBody]
    public CustomerInputModel Body { get; set; } = null!;
}
