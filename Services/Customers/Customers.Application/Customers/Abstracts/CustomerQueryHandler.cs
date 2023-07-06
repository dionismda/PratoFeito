namespace Customers.Application.Customers.Abstracts;

public abstract class CustomerQueryHandler<TQueryRequest, TResponse> : QueryHandler<Customer, TQueryRequest, TResponse>
    where TQueryRequest : IQuery<TResponse>
{
    protected CustomerQueryHandler(ICustomerRepository repository) : base(repository)
    {
    }
}
