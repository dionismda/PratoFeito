namespace Architecture.Api.Abstracts;

[ApiController]
[Produces("application/json")]
[Consumes("application/json")]
public abstract class BaseController : ControllerBase
{
    protected IMapper Mapper { get; set; }

    protected BaseController(IMapper mapper)
    {
        Mapper = mapper;
    }

    protected async Task<ActionResult<IList<TDto>>> ExecuteAsync<TDto, TEntity>(Func<Task<IList<TEntity>>> func)
    {
        var dbResult = await func();

        var apiResult = Mapper.Map<IList<TDto>>(dbResult);

        return Ok(apiResult);
    }

    protected async Task<ActionResult<TDto>> ExecuteAsync<TDto, TEntity>(Func<Task<TEntity>> func)
    {
        var dbResult = await func();

        var apiResult = Mapper.Map<TDto>(dbResult);

        return Ok(apiResult);
    }

    protected async Task<ActionResult> ExecuteAsync(Func<Task> func)
    {
        await func();

        return NoContent();
    }
}
