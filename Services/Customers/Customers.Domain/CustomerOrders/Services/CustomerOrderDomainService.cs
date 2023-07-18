namespace Customers.Domain.CustomerOrders.Services;

public sealed class CustomerOrderDomainService : DomainService<CustomerOrder>, ICustomerOrderDomainService
{
    public CustomerOrderDomainService(ICustomerOrderRepository repository) : base(repository)
    {
    }

    public async Task<IList<CustomerOrder>> GetCustomerOrderAllAsync(CancellationToken cancellationToken)
    {
        return await Repository.GetAllAsync(new GetCustomerOrderAllSpecification(), cancellationToken);
    }

    public async Task<CustomerOrder?> GetCustomerOrderByIdAsync(Identifier id, CancellationToken cancellationToken)
    {
        return await Repository.GetByIdAsync(new GetCustomerOrderByIdSpecification(id), cancellationToken);
    }
}