namespace Customers.Application.Customers.Commands.CreateCustomers;

internal sealed class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand, Customer>
{
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Customer(request.Name, request.OrderLimit);

        _customerRepository.Insert(customer);

        await _customerRepository.CommitAsync(cancellationToken);

        return customer;
    }
}