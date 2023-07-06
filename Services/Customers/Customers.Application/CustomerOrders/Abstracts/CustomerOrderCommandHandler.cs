namespace Customers.Application.CustomerOrders.Abstracts;

public abstract class CustomerOrderCommandHandler<TCommandRequest, TResponse> : CommandHandler<CustomerOrder, TCommandRequest, TResponse>
    where TCommandRequest : ICommand<TResponse>
{
    protected new ICustomerOrderDomainService DomainService { get; private set; }
    protected CustomerOrderCommandHandler(ICustomerOrderDomainService domainService) : base(domainService)
    {
        DomainService = domainService;
    }
}

public abstract class CustomerOrderCommandHandler<TCommandRequest> : CommandHandler<CustomerOrder, TCommandRequest>
    where TCommandRequest : ICommand
{
    protected new ICustomerOrderDomainService DomainService { get; private set; }
    protected CustomerOrderCommandHandler(ICustomerOrderDomainService domainService) : base(domainService)
    {
        DomainService = domainService;
    }
}