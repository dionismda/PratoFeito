namespace Customer.Domain.Customers.DomainServices;

public sealed class CustomerDomainService : BaseDomainService<CustomerEntity, CustomerQueryModel>, ICustomerDomainService
{
    public CustomerDomainService(ICustomerRepository repository) : base(repository)
    {
    }
}
