namespace Authentication.Swagger;

public class SwaggerWarningResponseType
{
    [DefaultValue(new string[] { "The field \"Field1\" already exists", "The field \"Field1\" cannot be null" })]
    public List<string> Field1 { get; set; }

    [DefaultValue(new string[] { "The field \"Field2\" already exists" })]
    public List<string> Field2 { get; set; }
}
