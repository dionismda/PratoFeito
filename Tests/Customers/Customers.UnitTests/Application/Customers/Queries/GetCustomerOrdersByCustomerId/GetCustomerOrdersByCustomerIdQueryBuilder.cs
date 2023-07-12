namespace Customers.UnitTests.Application.Customers.Queries.GetCustomerOrdersByCustomerId;

public sealed class GetCustomerOrdersByCustomerIdQueryBuilder : Builders<GetCustomerOrdersByCustomerIdQueryBuilder, GetCustomerOrdersByCustomerIdQuery>
{
    private Identifier CustomerId { get; set; }

    public GetCustomerOrdersByCustomerIdQueryBuilder()
    {
        CustomerId = Identifier.CreateNew();
    }

    public override GetCustomerOrdersByCustomerIdQuery Build()
    {
        return new GetCustomerOrdersByCustomerIdQuery(CustomerId);
    }
}
