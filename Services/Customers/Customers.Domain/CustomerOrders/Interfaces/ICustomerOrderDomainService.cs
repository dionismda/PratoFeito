namespace Customers.Domain.CustomerOrders.Interfaces;

public interface ICustomerOrderDomainService : IDomainService<CustomerOrder>
{
    Task<IList<CustomerOrder>> GetCustomerOrderAllAsync(CancellationToken cancellationToken);
    Task<CustomerOrder?> GetCustomerOrderByIdAsync(Identifier id, CancellationToken cancellationToken);
}
