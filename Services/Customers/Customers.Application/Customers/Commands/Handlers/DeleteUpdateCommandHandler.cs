namespace Customers.Application.Customers.Commands.Handlers;

public sealed class DeleteUpdateCommandHandler : CustomerCommandHandler<DeleteCustomerCommand>
{
    public DeleteUpdateCommandHandler(ICustomerDomainService customerDomainService) : base(customerDomainService)
    {
    }

    public override async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        await DomainService.DeleteAsync(request.Id, cancellationToken);
    }
}
