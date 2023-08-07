namespace Customers.Application.Customers.Commands.DeleteCustomers;

public sealed class DeleteUpdateCommandHandler : ICommandHandler<DeleteCustomerOrderCommand>
{
    private readonly ICustomerRepository _customerRepository;

    public DeleteUpdateCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task Handle(DeleteCustomerOrderCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetCustomerByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException($"Not found customer id {request.Id}");

        _customerRepository.Delete(customer);

        await _customerRepository.CommitAsync(cancellationToken);
    }
}
