namespace Customers.Application.Customers.Queries.GetCustomerOrdersByCustomerId;

public sealed class GetCustomerOrdersByCustomerIdQueryHandler : IQueryHandler<GetCustomerOrdersByCustomerIdQuery, IList<GetCustomerOrdersByCustomerIdQueryModel>>
{
    private readonly ICustomerQueries _customerQueries;

    public GetCustomerOrdersByCustomerIdQueryHandler(ICustomerQueries customerQueries)
    {
        _customerQueries = customerQueries;
    }

    public async Task<IList<GetCustomerOrdersByCustomerIdQueryModel>> Handle(GetCustomerOrdersByCustomerIdQuery request, CancellationToken cancellationToken)
    {
        return await _customerQueries.GetCustomerOrdersByCustomerIdAsync(request.CustomerId, cancellationToken);
    }
}