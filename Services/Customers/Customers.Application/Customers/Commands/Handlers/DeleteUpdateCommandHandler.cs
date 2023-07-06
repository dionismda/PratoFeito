using Customers.Application.Customers.Abstracts;

namespace Customers.Application.Customers.Commands.Handlers;

public sealed class DeleteUpdateCommandHandler : CustomerCommandHandler<DeleteCustomerOrderCommand>
{
    public DeleteUpdateCommandHandler(ICustomerDomainService customerDomainService) : base(customerDomainService)
    {
    }

    public override async Task Handle(DeleteCustomerOrderCommand request, CancellationToken cancellationToken)
    {
        await DomainService.DeleteAsync(request.Id, cancellationToken);
    }
}
