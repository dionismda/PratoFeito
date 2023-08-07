namespace Customers.Domain.Customers.Interfaces;

public interface ICustomerRepository : IGenericRepository<Customer>
{
    Task<IList<Customer>> GetCustomerAllAsync(CancellationToken cancellationToken);
    Task<bool> IsNameUniqueAsync(PersonName name, CancellationToken cancellationToken);
    Task<Customer?> GetCustomerByIdAsync(Identifier id, CancellationToken cancellationToken);
}