namespace Customers.UnitTests.Application.Customers.Queries.GetCustomerById;

public sealed class GetCustomerByIdQueryBuilder : Builders<GetCustomerByIdQueryBuilder, GetCustomerByIdQuery>
{
    private Identifier Id { get; set; }

    public GetCustomerByIdQueryBuilder()
    {
        Id = Identifier.CreateNew();
    }

    public override GetCustomerByIdQuery Build()
    {
        return new GetCustomerByIdQuery(Id);
    }
}
