using _Shared.ValueObjects.Abstractions;

namespace _Shared.ValueObjects._Commons;

public class Identifier : ValueObject<Identifier>
{
    public Guid Id { get; private set; }

    [JsonConstructor]
    public Identifier(Guid id)
    {
        Id = id;
    }

    public Identifier(string id)
    {
        Id = new Guid(id);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Id;
    }

    public override string ToString()
    {
        return Id.ToString();
    }

    public static Identifier CreateNew()
    {
        return new Identifier(Guid.NewGuid());
    }
}
