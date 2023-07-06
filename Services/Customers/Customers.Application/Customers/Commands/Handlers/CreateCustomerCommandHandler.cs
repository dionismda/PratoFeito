namespace Customers.Application.Customers.Commands.Handlers;

public sealed class CreateCustomerCommandHandler : CustomerCommandHandler<CreateCustomerCommand, Customer>
{
    private readonly IMapper _mapper;

    public CreateCustomerCommandHandler(IMapper mapper, ICustomerDomainService domainService) : base(domainService)
    {
        _mapper = mapper;
    }

    public override async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = _mapper.Map<Customer>(request);

        await DomainService.InsertAsync(customer, cancellationToken);

        return customer;
    }
}