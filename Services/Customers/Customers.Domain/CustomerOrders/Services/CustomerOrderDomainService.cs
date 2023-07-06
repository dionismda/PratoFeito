namespace Customers.Domain.CustomerOrders.Services;

public sealed class CustomerOrderDomainService : DomainService<CustomerOrder>, ICustomerOrderDomainService
{
    public CustomerOrderDomainService(ICustomerOrderRepository repository) : base(repository)
    {
    }

    public async Task<CustomerOrder?> GetCustomerOrderAsync(Identifier id, CancellationToken cancellationToken)
    {
        return await Repository.GetByIdAsync(id, cancellationToken);
    }
}