namespace Customers.Application.Customers.Commands.CreateCustomers;

public sealed class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand, Customer>
{
    private readonly IMapper _mapper;
    private readonly ICustomerDomainService _customerDomainService;

    public CreateCustomerCommandHandler(IMapper mapper, ICustomerDomainService customerDomainService)
    {
        _mapper = mapper;
        _customerDomainService = customerDomainService;
    }

    public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = _mapper.Map<Customer>(request);

        await _customerDomainService.InsertAsync(customer, cancellationToken);

        return customer;
    }
}