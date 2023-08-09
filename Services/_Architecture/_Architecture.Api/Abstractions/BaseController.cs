namespace _Architecture.Api.Abstractions;

[ApiController]
[Produces("application/json")]
[Consumes("application/json")]
public abstract class BaseController : ControllerBase
{
    protected IMapper Mapper { get; private set; }

    protected BaseController(IMapper mapper)
    {
        Mapper = mapper;
    }

    protected async Task<ActionResult<ResponseSuccess<IList<TDto>>>> ExecuteAsync<TDto, TEntity>(Func<Task<IList<TEntity>>> func)
    {
        var dbResult = await func();

        var apiResult = Mapper.Map<IList<TDto>>(dbResult);

        return ResponseSuccess("Request completed successfully", apiResult);
    }

    protected async Task<ActionResult<ResponseSuccess<TDto>>> ExecuteAsync<TDto, TEntity>(Func<Task<TEntity>> func)
    {
        var dbResult = await func();

        var apiResult = Mapper.Map<TDto>(dbResult);

        return ResponseSuccess("Request completed successfully", apiResult);
    }

    protected async Task<ActionResult> ExecuteAsync(Func<Task> func)
    {
        await func();

        return NoContent();
    }

    protected OkObjectResult ResponseSuccess<TResponse>(string message, TResponse result)
    {
        return Ok(new ResponseSuccess<TResponse>(message, result));
    }
}
