namespace Customers.Domain.CustomerOrders.Interfaces;

public interface ICustomerOrderRepository : IGenericRepository<CustomerOrder>
{
    Task<IList<CustomerOrder>> GetCustomerOrderAllAsync(CancellationToken cancellationToken);
    Task<CustomerOrder?> GetCustomerOrderByIdAsync(Identifier id, CancellationToken cancellationToken);
}
