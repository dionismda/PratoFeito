namespace Customers.Application.Customers.Queries.GetCustomers;

public sealed class GetCustomersQueryHandler : IQueryHandler<GetCustomersQuery, IList<Customer>>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomersQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<IList<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        return await _customerRepository.GetAllAsync(new GetCustomerAllSpecification(), cancellationToken);
    }
}