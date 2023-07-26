namespace Customers.Application.Customers.Commands.DeleteCustomers;

public sealed class DeleteUpdateCommandHandler : ICommandHandler<DeleteCustomerOrderCommand>
{
    private readonly ICustomerDomainService _customerDomainService;
    private readonly ICustomerRepository _customerRepository;

    public DeleteUpdateCommandHandler(ICustomerDomainService customerDomainService, ICustomerRepository customerRepository)
    {
        _customerDomainService = customerDomainService;
        _customerRepository = customerRepository;
    }

    public async Task Handle(DeleteCustomerOrderCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetCustomerByIdAsync(request.Id, cancellationToken);

        if (customer is null)
        {
            throw new NotFoundException($"Not found customer id {request.Id}");
        }

        await _customerDomainService.DeleteAsync(customer, cancellationToken);
    }
}
