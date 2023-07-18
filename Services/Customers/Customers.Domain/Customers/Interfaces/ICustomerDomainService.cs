namespace Customers.Domain.Customers.Interfaces;

public interface ICustomerDomainService : IDomainService<Customer>
{
    Task<IList<Customer>> GetCustomerAllAsync(CancellationToken cancellationToken);
    Task<Customer?> GetCustomerByIdAsync(Identifier id, CancellationToken cancellationToken);
}