namespace Customers.Application.Customers.Queries.GetCustomerById;

public sealed class GetCustomerByIdQueryHandler : IQueryHandler<GetCustomerByIdQuery, Customer?>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Customer?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        return await _customerRepository.GetByIdAsync(new GetCustomerByIdSpecification(request.Id), cancellationToken);
    }
}
