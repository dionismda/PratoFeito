namespace _Architecture.Infrastructure.Extensions;

public static class PropertyBuilderExtension
{
    public static PropertyBuilder<Identifier> IdentifierConversion(this PropertyBuilder<Identifier> property)
    {
        return property.HasConversion(
                id => id.Id,
                value => new Identifier(value),
                new ValueComparer<Identifier>(
                (l, r) => l.Equals(r),
                v => v.GetHashCode(),
                v => new Identifier(v.Id))
            );
    }

    public static PropertyBuilder<Money> MoneyConversion(this PropertyBuilder<Money> property)
    {
        return property.HasConversion(
                id => id.Amount,
                value => new Money(value),
                new ValueComparer<Money>(
                    (l, r) => l.Equals(r),
                    v => v.GetHashCode(),
                    v => new Money(v.Amount))
            );
    }
}
