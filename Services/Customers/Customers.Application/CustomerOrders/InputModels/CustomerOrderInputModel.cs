namespace Customers.Application.CustomerOrders.InputModels;

public class CreateCustomerOrderInputModel
{
    public Guid CustomerId { get; set; }
    public decimal OrderTotal { get; set; }
}

public class CustomerOrderDeliveredInputModel
{
    [FromRoute(Name = "id")]
    public Guid Id { get; set; }
}

public class CustomerOrderCanceledInputModel
{
    [FromRoute(Name = "id")]
    public Guid Id { get; set; }
}