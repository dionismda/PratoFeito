namespace AwsConfiguration;

public class AwsCredentials
{
    public string AccessKey { get; set; } = string.Empty;
    public string SecretKey { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public string? ServiceUrl { get; set; } = null;
}
