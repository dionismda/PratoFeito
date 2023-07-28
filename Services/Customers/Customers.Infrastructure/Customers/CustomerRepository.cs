namespace Customers.Infrastructure.Customers;

public sealed class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(CustomersContext context) : base(context)
    {
    }

    public async Task<IList<Customer>> GetCustomerAllAsync(CancellationToken cancellationToken)
    {
        return await FindAllAsync(new GetCustomerAllSpecification(), cancellationToken);
    }

    public async Task<Customer?> GetCustomerByIdAsync(Identifier id, CancellationToken cancellationToken)
    {
        return await FindByAsync(new GetCustomerByIdSpecification(id), cancellationToken);
    }

    public async Task<IList<Customer>> GetCustomerDuplicateAsync(Customer customer, CancellationToken cancellationToken)
    {
        return await FindAllAsync(new GetCustomerDuplicate(customer), cancellationToken);
    }
}