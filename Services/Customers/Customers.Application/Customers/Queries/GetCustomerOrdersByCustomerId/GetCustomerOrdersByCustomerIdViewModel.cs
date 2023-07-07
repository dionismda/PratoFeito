namespace Customers.Application.Customers.Queries.GetCustomerOrdersByCustomerId;

public class GetCustomerOrdersByCustomerIdViewModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public List<CustomerOrdersByCustomerIdViewModel> Orders { get; set; } = new();
}

public class CustomerOrdersByCustomerIdViewModel
{
    public decimal OrderTotal { get; set; }
    public CustomerOrderState State { get; set; }
}
