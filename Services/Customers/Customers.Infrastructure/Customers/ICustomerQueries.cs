namespace Customers.Infrastructure.Customers;

public interface ICustomerQueries
{
    Task<IList<GetCustomersQueryModel>> GetCustomersAsync(CancellationToken cancellationToken);
    Task<GetCustomerByIdQueryModel?> GetCustomerByIdAsync(Identifier CustomerId, CancellationToken cancellationToken);
    Task<IList<GetCustomerOrdersByCustomerIdQueryModel>> GetCustomerOrdersByCustomerIdAsync(Identifier CustomerId, CancellationToken cancellationToken);
}
