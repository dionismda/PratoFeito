using Customers.Application.Customers.Abstracts;

namespace Customers.Application.Customers.Queries.GetCustomers;

public sealed class GetCustomersQueryHandler : CustomerQueryHandler<GetCustomersQuery, IList<Customer>>
{
    public GetCustomersQueryHandler(ICustomerRepository customerRepository) : base(customerRepository)
    {
    }

    public override async Task<IList<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        return await Repository.GetAllAsync(cancellationToken);
    }
}