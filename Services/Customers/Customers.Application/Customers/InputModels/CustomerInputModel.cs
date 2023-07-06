namespace Customers.Application.Customers.InputModels;

public class CustomerInputModel
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}

public class CreateCustomerInputModel
{
    [FromBody]
    public CustomerInputModel Body { get; set; } = null!;
}

public class UpdateCustomerInputModel
{
    [FromRoute(Name = "id")]
    public Guid Id { get; set; }

    [FromBody]
    public CustomerInputModel Body { get; set; } = null!;
}

public class DeleteCustomerInputModel
{
    [FromRoute(Name = "id")]
    public Guid Id { get; set; }
}

public class GetCustomersInputModel
{
}

public class GetCustomerByIdInputModel
{
    [FromRoute(Name = "id")]
    public Guid Id { get; set; }
}