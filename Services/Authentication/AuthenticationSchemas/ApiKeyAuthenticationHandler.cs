namespace Authentication.AuthenticationSchemas;

public class ApiKeyAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly DefaultSetting _defaultSetting;
    private readonly ICipherCryptographyService _cipherCryptography;

    public ApiKeyAuthenticationHandler(ICipherCryptographyService cipherCryptography,
                                       IOptions<DefaultSetting> appOptions,
                                       IHttpContextAccessor httpContextAccessor,
                                       IOptionsMonitor<AuthenticationSchemeOptions> options,
                                       ILoggerFactory logger,
                                       UrlEncoder encoder,
                                       ISystemClock clock) : base(options, logger, encoder, clock)
    {
        _httpContextAccessor = httpContextAccessor;
        _defaultSetting = appOptions.Value;
        _cipherCryptography = cipherCryptography;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var authorizationHeader = _httpContextAccessor?.HttpContext?.Request.Headers["XApiKey"].ToString();

        if (string.IsNullOrEmpty(authorizationHeader) || !ValidateAuthorization(authorizationHeader))
        {
            throw new UnauthorizedException();
        }

        var claims = new Claim[] { new Claim(ClaimTypes.Name, _defaultSetting.DefaultSecretKey) };
        var claimsIdentity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(claimsIdentity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        return await Task.FromResult(AuthenticateResult.Success(ticket));
    }

    private bool ValidateAuthorization(string authorization)
    {
        return _defaultSetting.DefaultSecretKey == _cipherCryptography.Decrypt(authorization);
    }
}
