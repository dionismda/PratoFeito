namespace Monolith.Settings;

public class SwaggerSettings
{
    public string Title { get; set; } = string.Empty;
    public string JsonRoute { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<Microservice> Microservices { get; set; } = new();

    public class Microservice
    {
        public string Name { get; set; } = string.Empty;
    }
}
