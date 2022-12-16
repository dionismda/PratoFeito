namespace Authentication.Controllers;

[ApiController]
[Authorize(AuthenticationSchemes = "ApiKey")]
[Produces("application/json")]
[Consumes("application/json")]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class AccountController : ControllerBase
{
    private readonly SignInManager<IdentityUser<Guid>> _signInManager;
    private readonly UserManager<IdentityUser<Guid>> _userManager;
    private readonly JwtOptions _jwtOptions;

    public AccountController(SignInManager<IdentityUser<Guid>> signInManager, 
                             UserManager<IdentityUser<Guid>> userManager,
                             IOptions<JwtOptions> jwtOptions)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _jwtOptions = jwtOptions.Value;
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ResponseWarning<SwaggerWarningResponseType>), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ResponseUnauthorized), (int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType(typeof(ResponseError), (int)HttpStatusCode.InternalServerError)]
    public async Task<ActionResult<ResponseSuccess<AccountViewModel>>> Post(
        CreateAccountInputModel inputModel,
        CancellationToken cancellation)
    {
        var user = new IdentityUser<Guid>()
        {
            UserName = inputModel.Body.Username,
            Email = inputModel.Body.Email,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(user, inputModel.Body.Password);

        if (result.Succeeded)
            await _userManager.SetLockoutEnabledAsync(user, false);
        else
            throw new ArgumentException("Cannot create user");

        var accountViewModel = new AccountViewModel() { Id = user.Id, Username = user.UserName, Email = user.Email };

        return Ok(new ResponseSuccess<AccountViewModel>("Account created", accountViewModel));
    }

    [HttpPost("Login")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ResponseWarning<SwaggerWarningResponseType>), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ResponseUnauthorized), (int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType(typeof(ResponseError), (int)HttpStatusCode.InternalServerError)]
    public async Task<ActionResult<ResponseSuccess<AccountLoginViewModel>>> Login(
        [FromBody] AccountLoginInputModel inputModel,
        CancellationToken cancellation)
    {
        var user = await _userManager.FindByEmailAsync(inputModel.Login);

        if (user == null)
            throw new AuthenticationException("User or password is incorrect");

        if (!user.EmailConfirmed)
            throw new AuthenticationException("User account not confirmed email");

        var result = await _signInManager.PasswordSignInAsync(user, inputModel.Password, false, true);
        if (!result.Succeeded)
        {
            if (result.IsLockedOut)
                throw new AuthenticationException("User account is blocked");
            if (result.IsNotAllowed)
                throw new AuthenticationException("User account not has login permission");
            if (result.RequiresTwoFactor)
                throw new AuthenticationException("User account confirm two authentication factor");

            throw new AuthenticationException("User or password is incorrect");
        }

        var claims = new List<Claim>()
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString("N")),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()),
            new(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
            new("TenantId", user.Id.ToString("N")),
        };

        var token = new JwtSecurityTokenHandler()
                            .WriteToken(new JwtSecurityToken(
                                issuer: _jwtOptions.Issuer,
                                audience: _jwtOptions.Audience,
                                claims: claims,
                                notBefore: DateTime.Now,
                                expires: DateTime.Now.AddSeconds(_jwtOptions.AccessTokenExpiration),
                                signingCredentials: _jwtOptions.SigningCredentials)
                            );

        var accountLoginViewModel = new AccountLoginViewModel() { AccessToken = token };

        return Ok(new ResponseSuccess<AccountLoginViewModel>("Login successful ", accountLoginViewModel));
    }


}
