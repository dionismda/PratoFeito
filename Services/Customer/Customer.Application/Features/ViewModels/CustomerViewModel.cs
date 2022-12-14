namespace Customer.Application.Features.ViewModels;

public class CustomerViewModel
{
    [DefaultValue("c56a4180-65aa-42ec-a945-5fd21dec0538")]
    public Guid Id { get; set; }

    [DefaultValue("João")]
    public string FirstName { get; set; } = string.Empty;

    [DefaultValue("da Silva")]
    public string LastName { get; set; } = string.Empty;

    [DefaultValue("150,00")]
    public decimal Amount { get; set; }
}
