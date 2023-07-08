namespace _Architecture.Domain.Abstracts;

public abstract class ValueObject<TValueObject>
        where TValueObject : ValueObject<TValueObject>
{
    protected static bool EqualOperator(ValueObject<TValueObject>? left, ValueObject<TValueObject>? right)
    {
        if (left is null ^ right is null)
        {
            return false;
        }

        return left is null || left.Equals(right);
    }

    protected static bool NotEqualOperator(ValueObject<TValueObject>? left, ValueObject<TValueObject>? right)
    {
        return !EqualOperator(left, right);
    }

    protected abstract IEnumerable<object?> GetEqualityComponents();

    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType())
        {
            return false;
        }

        var other = (ValueObject<TValueObject>)obj;

        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
    }

    public ValueObject<TValueObject>? GetCopy()
    {
        return MemberwiseClone() as ValueObject<TValueObject>;
    }
}