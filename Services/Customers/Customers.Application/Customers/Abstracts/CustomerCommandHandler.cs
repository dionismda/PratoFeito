namespace Customers.Application.Customers.Abstracts;

public abstract class CustomerCommandHandler<TCommandRequest, TResponse> : CommandHandler<Customer, TCommandRequest, TResponse>
    where TCommandRequest : ICommand<TResponse>
{
    protected CustomerCommandHandler(ICustomerDomainService domainService) : base(domainService)
    {
    }
}

public abstract class CustomerCommandHandler<TCommandRequest> : CommandHandler<Customer, TCommandRequest>
    where TCommandRequest : ICommand
{
    protected CustomerCommandHandler(ICustomerDomainService domainService) : base(domainService)
    {
    }
}