namespace Customers.Api.CustomerOrders;

[Route("api/[controller]")]
public class CustomerOrderController : BaseController
{
    private readonly IMediator _mediator;

    public CustomerOrderController(IMediator mediator, IMapper mapper) : base(mapper)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CustomerOrderViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CustomerOrderViewModel>> Post([FromBody] CreateCustomerOrderInputModel inputModel, CancellationToken cancellation)
        => await ExecuteAsync<CustomerOrderViewModel, CustomerOrder>(async ()
            => await _mediator.Send(Mapper.Map<CreateCustomerOrderCommand>(inputModel), cancellation));

    [HttpPut("{id:guid}/Delivered")]
    [ProducesResponseType(typeof(CustomerOrderViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CustomerOrderViewModel>> OrderDelivered(CustomerOrderDeliveredInputModel inputModel, CancellationToken cancellation)
        => await ExecuteAsync<CustomerOrderViewModel, CustomerOrder>(async ()
            => await _mediator.Send(Mapper.Map<DeliveredCustomerOrderCommand>(inputModel), cancellation));

    [HttpPut("{id:guid}/Canceled")]
    [ProducesResponseType(typeof(CustomerOrderViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CustomerOrderViewModel>> OrderCanceled(CustomerOrderCanceledInputModel inputModel, CancellationToken cancellation)
        => await ExecuteAsync<CustomerOrderViewModel, CustomerOrder>(async ()
            => await _mediator.Send(Mapper.Map<CancelCustomerOrderCommand>(inputModel), cancellation));
}
