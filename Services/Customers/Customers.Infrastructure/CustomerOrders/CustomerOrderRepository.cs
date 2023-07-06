namespace Customers.Infrastructure.CustomerOrders;

public sealed class CustomerOrderRepository : Repository<CustomerOrder>, ICustomerOrderRepository
{
    public CustomerOrderRepository(CustomersContext context) : base(context)
    {
    }
}
