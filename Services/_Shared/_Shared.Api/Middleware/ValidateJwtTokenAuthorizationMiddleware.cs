namespace _Shared.Api.Middleware;

public class ValidateJwtTokenAuthorizationMiddleware : IMiddleware
{
    private readonly DataBaseSetting _settings;

    public ValidateJwtTokenAuthorizationMiddleware(IOptions<DataBaseSetting> settings)
    {
        _settings = settings.Value;
    }

    private static string RemoveBearerPrefix(string authorization)
    {
        const string remove = "Bearer ";

        var index = authorization.IndexOf(remove, StringComparison.Ordinal);

        return index < 0
            ? authorization
            : authorization.Remove(index, remove.Length);
    }

    private void ReadClaims(HttpContext context, IEnumerable<Claim> claims)
    {
        var config = context.RequestServices.GetService<IDbContextConfig>();

        if (config is null)
            return;

        var tenantId = claims.Where(x => x.Type == "TenantId").Select(x => x.Value).First();

        config.SetConfig(_settings.DefaultServer, 
                         _settings.DefaultPort, 
                         _settings.DefaultDatabase, 
                         _settings.DefaultDatabaseUser, 
                         _settings.DefaultDatabasePass, 
                         Guid.Parse(tenantId));
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var authorizationBearer = context.Request.Headers["Authorization"].ToString();

        if (!string.IsNullOrWhiteSpace(authorizationBearer))
        {
            ReadClaims(context, new JwtSecurityTokenHandler().ReadJwtToken(RemoveBearerPrefix(authorizationBearer)).Claims);
        }

        await next(context);
    }
}
