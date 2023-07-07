namespace Customers.Application.Customers.Commands.DeleteCustomers;

public sealed class DeleteUpdateCommandHandler : ICommandHandler<DeleteCustomerOrderCommand>
{
    private readonly ICustomerDomainService _customerDomainService;

    public DeleteUpdateCommandHandler(ICustomerDomainService customerDomainService)
    {
        _customerDomainService = customerDomainService;
    }

    public async Task Handle(DeleteCustomerOrderCommand request, CancellationToken cancellationToken)
    {
        await _customerDomainService.DeleteAsync(request.Id, cancellationToken);
    }
}
