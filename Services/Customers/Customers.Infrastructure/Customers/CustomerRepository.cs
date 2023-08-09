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

    public async Task<bool> IsNameUniqueAsync(PersonName name, CancellationToken cancellationToken)
    {
        var result = await FindAllAsync(new GetCustomerByNameSpecification(name), cancellationToken);

        return result.Any();
    }

    public async Task<bool> IsNameUniqueAsync(PersonName name, Identifier id, CancellationToken cancellationToken)
    {
        var result = await FindAllAsync(new GetCustomerByNameSpecification(name, id), cancellationToken);

        return result.Any();
    }
}