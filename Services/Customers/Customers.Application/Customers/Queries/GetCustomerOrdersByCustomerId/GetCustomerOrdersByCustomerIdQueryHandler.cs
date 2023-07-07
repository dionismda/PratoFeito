namespace Customers.Application.Customers.Queries.GetCustomerOrdersByCustomerId;

public sealed class GetCustomerOrdersByCustomerIdQueryHandler : IQueryHandler<GetCustomerOrdersByCustomerIdQuery, GetCustomerOrdersByCustomerIdViewModel?>
{
    private readonly ICustomerQueires _customerQueires;

    public GetCustomerOrdersByCustomerIdQueryHandler(ICustomerQueires customerQueires)
    {
        _customerQueires = customerQueires;
    }

    public async Task<GetCustomerOrdersByCustomerIdViewModel?> Handle(GetCustomerOrdersByCustomerIdQuery request, CancellationToken cancellationToken)
    {
        return await _customerQueires.GetCustomerOrdersByCustomerIdAsync(request.Id, cancellationToken);
    }
}
