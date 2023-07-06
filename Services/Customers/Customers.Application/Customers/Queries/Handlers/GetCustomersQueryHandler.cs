namespace Customers.Application.Customers.Queries.Handlers;

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