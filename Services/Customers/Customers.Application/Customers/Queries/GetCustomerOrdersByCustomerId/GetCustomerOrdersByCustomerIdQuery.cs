namespace Customers.Application.Customers.Queries.GetCustomerOrdersByCustomerId;

public sealed class GetCustomerOrdersByCustomerIdQuery : IQuery<IList<GetCustomerOrdersByCustomerIdQueryModel>>
{
    public Identifier CustomerId { get; private set; } = null!;

    private GetCustomerOrdersByCustomerIdQuery()
    {
    }

    public GetCustomerOrdersByCustomerIdQuery(Identifier customerId) : this()
    {
        CustomerId = customerId;
    }
}
