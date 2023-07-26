namespace Customers.Domain.Customers.Interfaces;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<IList<Customer>> GetCustomerAllAsync(CancellationToken cancellationToken);
    Task<IList<Customer>> GetCustomerDuplicateAsync(Customer customer, CancellationToken cancellationToken);
    Task<Customer?> GetCustomerByIdAsync(Identifier id, CancellationToken cancellationToken);
}