namespace Customers.Infrastructure.CustomerOrders;

public sealed class CustomerOrderRepository : Repository<CustomerOrder>, ICustomerOrderRepository
{
    public CustomerOrderRepository(CustomersContext context) : base(context)
    {
    }

    public async Task<IList<CustomerOrder>> GetCustomerOrderAllAsync(CancellationToken cancellationToken)
    {
        return await FindAllAsync(new GetCustomerOrderAllSpecification(), cancellationToken);
    }

    public async Task<CustomerOrder?> GetCustomerOrderByIdAsync(Identifier id, CancellationToken cancellationToken)
    {
        return await FindByAsync(new GetCustomerOrderByIdSpecification(id), cancellationToken);
    }
}
