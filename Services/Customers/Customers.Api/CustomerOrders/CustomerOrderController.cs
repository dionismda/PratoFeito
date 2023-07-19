namespace Customers.Api.CustomerOrders;

[Route("api/[controller]")]
[ApiExplorerSettings(GroupName = nameof(ContextEnum.Customers))]
public class CustomerOrderController : BaseController
{
    private readonly IMediator _mediator;

    public CustomerOrderController(IMediator mediator, IMapper mapper) : base(mapper)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ResponseWarning<WarningResponseType>), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ResponseError), (int)HttpStatusCode.InternalServerError)]
    public async Task<ActionResult<ResponseSuccess<CustomerOrderViewModel>>> Post([FromBody] CreateCustomerOrderInputModel inputModel, CancellationToken cancellation)
        => await ExecuteAsync<CustomerOrderViewModel, CustomerOrder>(async ()
            => await _mediator.Send(Mapper.Map<CreateCustomerOrderCommand>(inputModel), cancellation));

    [HttpPut("{id:guid}/Delivered")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ResponseWarning<WarningResponseType>), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ResponseError), (int)HttpStatusCode.InternalServerError)]
    public async Task<ActionResult<ResponseSuccess<CustomerOrderViewModel>>> OrderDelivered(CustomerOrderDeliveredInputModel inputModel, CancellationToken cancellation)
        => await ExecuteAsync<CustomerOrderViewModel, CustomerOrder>(async ()
            => await _mediator.Send(Mapper.Map<DeliveredCustomerOrderCommand>(inputModel), cancellation));

    [HttpPut("{id:guid}/Canceled")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ResponseWarning<WarningResponseType>), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ResponseError), (int)HttpStatusCode.InternalServerError)]
    public async Task<ActionResult<ResponseSuccess<CustomerOrderViewModel>>> OrderCanceled(CustomerOrderCanceledInputModel inputModel, CancellationToken cancellation)
        => await ExecuteAsync<CustomerOrderViewModel, CustomerOrder>(async ()
            => await _mediator.Send(Mapper.Map<CancelCustomerOrderCommand>(inputModel), cancellation));
}
