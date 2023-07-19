namespace Customers.Infrastructure.Customers;

public sealed class CustomerQueries : DapperQueries, ICustomerQueries
{
    private const string CustomerSchema = "Customers";

    public CustomerQueries(IConnectionDapper connectionDapper) : base(connectionDapper)
    {
    }

    public async Task<GetCustomerByIdQueryModel?> GetCustomerByIdAsync(Identifier CustomerId, CancellationToken cancellationToken)
    {
        using var connection = await ConnectionDapper.GetConnectionAsync(CustomerSchema);

        var sql = @"SELECT
                        customer_id as id,
                        firstname,
                        lastname,
                        order_limit
                    FROM
                        customers
                    WHERE
                        customer_id = @customer_id
                   ";

        return await connection.QueryFirstOrDefaultAsync<GetCustomerByIdQueryModel>(sql, new { customer_id = CustomerId.Id });
    }

    public async Task<IList<GetCustomerOrdersByCustomerIdQueryModel>> GetCustomerOrdersByCustomerIdAsync(Identifier CustomerId, CancellationToken cancellationToken)
    {
        using var connection = await ConnectionDapper.GetConnectionAsync(CustomerSchema);

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
