namespace Customers.Application.CustomerOrders.Commands.CreateCustomerOrder;

public sealed class CreateCustomerOrderCommandHandler : ICommandHandler<CreateCustomerOrderCommand, CustomerOrder>
{
    private readonly IMapper _mapper;
    private readonly ICustomerOrderDomainService _customerOrderDomainService;

    public CreateCustomerOrderCommandHandler(IMapper mapper, ICustomerOrderDomainService customerOrderDomainService)
    {
        _mapper = mapper;
        _customerOrderDomainService = customerOrderDomainService;
    }

    public async Task<CustomerOrder> Handle(CreateCustomerOrderCommand request, CancellationToken cancellationToken)
    {
        var customerOrder = _mapper.Map<CustomerOrder>(request);

        await _customerOrderDomainService.InsertAsync(customerOrder, cancellationToken);

        return customerOrder;
    }
}
