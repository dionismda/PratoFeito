namespace Customers.Infrastructure.Customers;

public sealed class CustomerQueries : DapperQueries, ICustomerQueries
{
    public CustomerQueries(IConnectionDapper connectionDapper) : base(connectionDapper)
    {
    }

    public async Task<IList<GetCustomerOrdersByCustomerIdQueryModel>> GetCustomerOrdersByCustomerId(Identifier CustomerId, CancellationToken cancellationToken)
    {
        using var connection = await ConnectionDapper.GetConnectionAsync();

        var sql = @"SELECT
                        customer_order_id as id,
                        customer_id,
                        state,
                        order_total
                    FROM
                        customer_orders
                    WHERE
                        customer_id = @customer_id
                   ";

        var results = await connection.QueryAsync<GetCustomerOrdersByCustomerIdQueryModel>(sql, new { customer_id = CustomerId.Id });

        return results.ToList();
    }
}
