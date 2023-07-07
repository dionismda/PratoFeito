namespace Customers.Domain.CustomerOrders.Services;

public sealed class CustomerOrderDomainService : DomainService<CustomerOrder>, ICustomerOrderDomainService
{
    public CustomerOrderDomainService(ICustomerOrderRepository repository) : base(repository)
    {
    }
}