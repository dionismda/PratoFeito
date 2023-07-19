namespace _Architecture.Api.Swaggers.Exemples;

public class WarningResponseType
{
    [DefaultValue(new string[] { "Campo \"Field1\" já existe", "Campo \"Field1\" não pode ser nulo" })]
    public List<string> Field1 { get; set; } = new();

    [DefaultValue(new string[] { "Campo \"Field2\" já existe" })]
    public List<string> Field2 { get; set; } = new();
}
