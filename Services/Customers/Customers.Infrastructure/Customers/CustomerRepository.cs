namespace Customers.Infrastructure.Customers;

public sealed class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(CustomersContext context) : base(context)
    {
    }
}