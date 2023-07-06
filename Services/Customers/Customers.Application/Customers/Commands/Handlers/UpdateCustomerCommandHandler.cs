namespace Customers.Application.Customers.Commands.Handlers;

public sealed class UpdateCustomerCommandHandler : CustomerCommandHandler<UpdateCustomerCommand, Customer>
{
    private readonly IMapper _mapper;

    public UpdateCustomerCommandHandler(IMapper mapper, ICustomerDomainService customerDomainService) : base(customerDomainService)
    {
        _mapper = mapper;
    }

    public override async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = _mapper.Map<Customer>(request);

        await DomainService.UpdateAsync(customer, cancellationToken);

        return customer;
    }
}
