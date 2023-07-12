namespace Customers.Application.Customers.Queries.GetCustomerById;

public sealed class GetCustomerByIdQuery : IQuery<Customer>
{
    public Identifier Id { get; private set; } = null!;

    private GetCustomerByIdQuery()
    {
    }

    public GetCustomerByIdQuery(Identifier id) : this()
    {
        Id = id;
    }
}