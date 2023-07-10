namespace PratoFeito_Customers.Api.Customers;

[Route("api/[controller]")]
public class CustomerController : BaseController
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator, IMapper mapper) : base(mapper)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IList<CustomerViewModel>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IList<CustomerViewModel>>> GetAll(CancellationToken cancellation)
        => await ExecuteAsync<CustomerViewModel, Customer>(async ()
            => await _mediator.Send(Mapper.Map<GetCustomersQuery>(new GetCustomersInputModel()), cancellation));

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(CustomerViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CustomerViewModel>> GetById([FromQuery] GetCustomerByIdInputModel inputModel, CancellationToken cancellation)
        => await ExecuteAsync<CustomerViewModel, Customer>(async ()
            => await _mediator.Send(Mapper.Map<GetCustomerByIdQuery>(inputModel), cancellation));

    [HttpPost]
    [ProducesResponseType(typeof(CustomerViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CustomerViewModel>> Post(CreateCustomerInputModel inputModel, CancellationToken cancellation)
        => await ExecuteAsync<CustomerViewModel, Customer>(async ()
            => await _mediator.Send(Mapper.Map<CreateCustomerCommand>(inputModel), cancellation));

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(CustomerViewModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CustomerViewModel>> Put(UpdateCustomerInputModel inputModel, CancellationToken cancellation)
        => await ExecuteAsync<CustomerViewModel, Customer>(async ()
            => await _mediator.Send(Mapper.Map<UpdateCustomerCommand>(inputModel), cancellation));

    [HttpDelete("{id:guid}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> Delete(DeleteCustomerInputModel inputModel, CancellationToken cancellation)
        => await ExecuteAsync(async ()
            => await _mediator.Send(Mapper.Map<DeleteCustomerOrderCommand>(inputModel), cancellation));
}