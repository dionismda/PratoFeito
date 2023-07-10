namespace Customers.Infrastructure.Customers;

public interface ICustomerQueries
{
    Task<IList<GetCustomerOrdersByCustomerIdQueryModel>> GetCustomerOrdersByCustomerId(Identifier CustomerId, CancellationToken cancellationToken);
}
