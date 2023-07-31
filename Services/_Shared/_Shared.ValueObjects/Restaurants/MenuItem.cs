namespace _Shared.ValueObjects.Restaurants;

public sealed class MenuItem : ValueObject<MenuItem>
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public Money Price { get; private set; }

    public MenuItem(string name, Money price)
    {
        Id = Guid.NewGuid();
        Name = name;
        Price = price;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Id;
        yield return Name;
        yield return Price;
    }
}
