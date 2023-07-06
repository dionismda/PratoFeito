namespace Customers.Application.CustomerOrders.Abstracts;

public abstract class CustomerOrderQueryHandler<TQueryRequest, TResponse> : QueryHandler<CustomerOrder, TQueryRequest, TResponse>
    where TQueryRequest : IQuery<TResponse>
{
    protected CustomerOrderQueryHandler(ICustomerOrderRepository repository) : base(repository)
    {
    }
}