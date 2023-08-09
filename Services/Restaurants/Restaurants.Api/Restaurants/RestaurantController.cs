namespace Restaurants.Api.Restaurants;

[Route("api/[controller]")]
[ApiExplorerSettings(GroupName = nameof(ContextEnum.Restaurants))]

public sealed class RestaurantController : BaseController
{
    private readonly IMediator _mediator;

    public RestaurantController(IMediator mediator, IMapper mapper) : base(mapper)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ResponseWarning<WarningResponseType>), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ResponseError), (int)HttpStatusCode.InternalServerError)]
    public async Task<ActionResult<ResponseSuccess<RestaurantViewModel>>> Post(CreateRestaurantInputModel inputModel, CancellationToken cancellation)
        => await ExecuteAsync<RestaurantViewModel, Restaurant>(async ()
            => await _mediator.Send(Mapper.Map<CreateRestaurantCommand>(inputModel), cancellation));
}
