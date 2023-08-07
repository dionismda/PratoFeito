namespace Customers.Application.Customers.Commands.UpdateCustomers;

public sealed class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand, Customer>
{
    private readonly ICustomerRepository _customerRepository;

    public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetCustomerByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException($"Customer not found {request.Id}");

        if (!request.Name.Equals(customer.Name))
            customer.ChangeName(request.Name);

        if (!request.OrderLimit.Equals(customer.OrderLimit))
            customer.ChangeOrderLimit(request.OrderLimit);

        _customerRepository.Update(customer);

        await _customerRepository.CommitAsync(cancellationToken);

        return customer;
    }
}
