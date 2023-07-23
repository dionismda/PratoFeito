namespace SerilogServices;

public static class SerilogExtensions
{
    public static List<Tag> AddMetadata(this List<Tag> tags, string key, string value) => tags.Add(key, value);

    private static List<Tag> Add(this List<Tag> tags, string key, object value)
    {
        tags.Add(new Tag(key, value));
        return tags;
    }
}
