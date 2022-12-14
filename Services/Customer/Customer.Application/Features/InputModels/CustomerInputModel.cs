namespace Customer.Application.Features.InputModels;

public class CustomerInputModel
{
    [DefaultValue("João")]
    public string FirstName { get; set; } = string.Empty;

    [DefaultValue("da Silva")]
    public string LastName { get; set; } = string.Empty;

    [DefaultValue("150,00")]
    public Decimal Amount { get; set; }
}


public class CreatePersonInputModel
{
    [FromBody, Required]
    public CustomerInputModel Body { get; set; }
}


public class UpdatePersonInputModel
{
    [JsonIgnore, FromRoute(Name = "id")]
    public Guid Id { get; set; }

    [FromBody, Required]
    public CustomerInputModel Body { get; set; }
}
