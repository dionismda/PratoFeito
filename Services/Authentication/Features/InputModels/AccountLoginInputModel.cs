namespace Authentication.Features.InputModels;

public class AccountLoginInputModel
{
    [JsonInclude, DefaultValue("xpto@teste.com.br")]
    public string Login { get; set; }

    [JsonInclude, DefaultValue("Abcdefgh123@")]
    public string Password { get; set; }
}
