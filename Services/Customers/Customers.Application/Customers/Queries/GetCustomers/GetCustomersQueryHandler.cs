namespace Customers.Application.Customers.Queries.GetCustomers;

internal sealed class GetCustomersQueryHandler : IQueryHandler<GetCustomersQuery, IList<GetCustomersQueryModel>>
{
    private readonly ICustomerQueries _customerQueries;

    public GetCustomersQueryHandler(ICustomerQueries customerQueries)
    {
        _customerQueries = customerQueries;
    }

    public async Task<IList<GetCustomersQueryModel>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        return await _customerQueries.GetCustomersAsync(cancellationToken);
    }
}