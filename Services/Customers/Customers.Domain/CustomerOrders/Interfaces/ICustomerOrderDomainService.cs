namespace Customers.Domain.CustomerOrders.Interfaces;

public interface ICustomerOrderDomainService : IDomainService<CustomerOrder>
{
    Task<CustomerOrder?> GetCustomerOrderAsync(Identifier id, CancellationToken cancellationToken);
}
