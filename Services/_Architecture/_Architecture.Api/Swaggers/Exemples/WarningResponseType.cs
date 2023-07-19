namespace _Architecture.Api.Swaggers.Exemples;

public class WarningResponseType
{
    [DefaultValue(new string[] { "Field \"Field1\" already exists", "Field \"Field1\" cannot be null" })]
    public List<string> Field1 { get; set; } = new();

    [DefaultValue(new string[] { "Field \"Field2\" already exists" })]
    public List<string> Field2 { get; set; } = new();
}
