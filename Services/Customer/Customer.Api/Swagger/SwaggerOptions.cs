namespace Customer.Api.Swagger;

public class SwaggerOptions
{    
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string JsonRoute { get; set; } = string.Empty;
    public List<Version> Versions { get; set; } = new List<Version>();

    public class Version
    {
        public string Name { get; set; } = string.Empty;
        public string UriEndpoint { get; set; } = string.Empty;
    }
}
