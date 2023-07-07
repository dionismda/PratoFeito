using Customers.Application.Customers.Abstracts;

namespace Customers.Application.Customers.Queries.GetCustomerById;

public sealed class GetCustomerByIdQueryHandler : CustomerQueryHandler<GetCustomerByIdQuery, Customer?>
{
    public GetCustomerByIdQueryHandler(ICustomerRepository repository) : base(repository)
    {
    }

    public override async Task<Customer?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        return await Repository.GetByIdAsync(request.Id, cancellationToken);
    }
}
