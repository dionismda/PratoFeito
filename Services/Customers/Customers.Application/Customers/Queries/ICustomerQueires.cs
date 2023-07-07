namespace Customers.Application.Customers.Queries;

public interface ICustomerQueires
{
    Task<GetCustomerOrdersByCustomerIdViewModel?> GetCustomerOrdersByCustomerIdAsync(Identifier id, CancellationToken cancellationToken);
}
