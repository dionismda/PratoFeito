namespace Customer.Api.Controllers;

[ApiVersion("1.0")]
public class CustomerController : BaseController
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public CustomerController(ICommandDispatcher commandDispatcher, 
                              IQueryDispatcher queryDispatcher) : base(commandDispatcher, queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ResponseWarning<SwaggerWarningResponseType>), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ResponseUnauthorized), (int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType(typeof(ResponseError), (int)HttpStatusCode.InternalServerError)]
    public async Task<ActionResult<CustomerViewModel>> Post(
        CreatePersonInputModel inputModel,
        CancellationToken cancellation)
    {
        //var command = Mapper.Map<CreatePersonCommand>(inputModel);

        var command = new CreateCustomerCommand(new PersonNameValueObject("asdasd", "qwqeqwe"), new MoneyValueObject(10));

        var result = await _commandDispatcher.Handle<CreateCustomerCommand, CustomerEntity>(command, cancellation);

        return Ok(new CustomerViewModel());
    }
}
