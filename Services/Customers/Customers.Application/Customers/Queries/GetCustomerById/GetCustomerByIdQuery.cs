namespace Customers.Application.Customers.Queries.GetCustomerById;

public sealed class GetCustomerByIdQuery : IQuery<Customer>
{
    public Identifier Id { get; private set; } = null!;

    public GetCustomerByIdQuery()
    {
    }

    public GetCustomerByIdQuery(Identifier id)
    {
        Id = id;
    }
}