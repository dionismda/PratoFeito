namespace Authentication.Features.InputModels;

public class AccountInputModel
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

public class CreateAccountInputModel
{
    [FromBody, Required]
    public AccountInputModel Body { get; set; }
}


public class UpdateAccountInputModel
{
    [JsonIgnore, FromRoute(Name = "id")]
    public Guid Id { get; set; }

    [FromBody, Required]
    public AccountInputModel Body { get; set; }
}
