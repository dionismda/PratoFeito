namespace Customers.Application.Customers.Queries.GetCustomerOrdersByCustomerId;

public sealed class GetCustomerOrdersByCustomerIdQuery : IQuery<GetCustomerOrdersByCustomerIdViewModel>
{
    public Identifier Id { get; private set; } = null!;

    public GetCustomerOrdersByCustomerIdQuery()
    {
    }

    public GetCustomerOrdersByCustomerIdQuery(Identifier id)
    {
        Id = id;
    }
}