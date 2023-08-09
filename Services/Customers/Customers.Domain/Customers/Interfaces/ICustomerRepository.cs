namespace Customers.Domain.Customers.Interfaces;

public interface ICustomerRepository : IGenericRepository<Customer>
{
    Task<bool> IsNameUniqueAsync(PersonName name, CancellationToken cancellationToken);
    Task<bool> IsNameUniqueAsync(PersonName name, Identifier id, CancellationToken cancellationToken);
    Task<Customer?> GetCustomerByIdAsync(Identifier id, CancellationToken cancellationToken);
}