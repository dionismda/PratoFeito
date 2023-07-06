namespace Customers.Application.CustomerOrders.Commands.Handlers;

public sealed class CreateCustomerOrderCommandHandler : CustomerOrderCommandHandler<CreateCustomerOrderCommand, CustomerOrder>
{
    private readonly IMapper _mapper;

    public CreateCustomerOrderCommandHandler(IMapper mapper, ICustomerOrderDomainService domainService) : base(domainService)
    {
        _mapper = mapper;
    }

    public override async Task<CustomerOrder> Handle(CreateCustomerOrderCommand request, CancellationToken cancellationToken)
    {
        var customerOrder = _mapper.Map<CustomerOrder>(request);

        await DomainService.InsertAsync(customerOrder, cancellationToken);

        return customerOrder;
    }
}
