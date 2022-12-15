namespace Authentication.Controllers
{
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

        public AccountController(SignInManager<IdentityUser<Guid>> signInManager, 
                                 UserManager<IdentityUser<Guid>> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseWarning<SwaggerWarningResponseType>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseUnauthorized), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ResponseError), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<AccountViewModel>> Post(
            CreateAccountInputModel inputModel,
            CancellationToken cancellation)
        {
            var user = new IdentityUser<Guid>()
            {
                UserName = inputModel.Body.Username,
                Email = inputModel.Body.Email
            };

            var result = await _userManager.CreateAsync(user, inputModel.Body.Password);

            if (result.Succeeded)
                await _userManager.SetLockoutEnabledAsync(user, false);
            else
                throw new ArgumentException("Cannot create user");

            return Ok(new AccountViewModel() { Id = user.Id, Username = user.UserName, Email = user.Email});
        }

    }
}
