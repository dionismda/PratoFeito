namespace Customers.Application.Customers.Commands.CreateCustomers;

public sealed class CreateCustomerInputModel
{
    [FromBody]
    public CustomerInputModel Body { get; set; } = null!;
}
