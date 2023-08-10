namespace Customers.Application.Customers.Queries.GetCustomerById;

public sealed class GetCustomerByIdQueryHandler : IQueryHandler<GetCustomerByIdQuery, GetCustomerByIdQueryModel?>
{
    private readonly ICustomerQueries _customerQueries;

    public GetCustomerByIdQueryHandler(ICustomerQueries customerRepository)
    {
        _customerQueries = customerRepository;
    }

    public async Task<GetCustomerByIdQueryModel?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        return await _customerQueries.GetCustomerByIdAsync(request.Id, cancellationToken);
    }
}
