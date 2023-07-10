using Customers.Infrastructure.Customers.Queries;

namespace Customers.Application.Customers.Queries.GetCustomerOrdersByCustomerId;

public sealed class GetCustomerOrdersByCustomerIdQuery : IQuery<IList<GetCustomerOrdersByCustomerIdQueryModel>>
{
    public Identifier CustomerId { get; private set; } = null!;

    public GetCustomerOrdersByCustomerIdQuery()
    {
    }

    public GetCustomerOrdersByCustomerIdQuery(Identifier customerId)
    {
        CustomerId = customerId;
    }
}
