namespace Customers.Application.Customers.Commands.UpdateCustomers;

public sealed class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand, Customer>
{
    private readonly IMapper _mapper;
    private readonly ICustomerDomainService _customerDomainService;

    public UpdateCustomerCommandHandler(IMapper mapper, ICustomerDomainService customerDomainService)
    {
        _mapper = mapper;
        _customerDomainService = customerDomainService;
    }

    public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = _mapper.Map<Customer>(request);

        await _customerDomainService.UpdateAsync(customer, cancellationToken);

        return customer;
    }
}
