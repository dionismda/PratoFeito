namespace Architecture.Domain.Abstracts;

public abstract class Entity
{
    public Identifier Id { get; protected set; }
    public DateTime CreatedAt { get; private set; } = DateTime.Now.ToUniversalTime();
    public DateTime? UpdatedAt { get; private set; } = null;

    protected Entity()
    {
        Id = Identifier.CreateNew();
    }

    public void ModifyUpdatedDate()
    {
        UpdatedAt = DateTime.UtcNow.ToUniversalTime();
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Entity other)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (GetRealType() != other.GetRealType())
            return false;

        if (Id == null || other.Id == null)
            return false;

        return Id == other.Id;
    }

    public override int GetHashCode()
    {
        return (GetRealType().ToString() + Id).GetHashCode();
    }

    public Type GetRealType()
    {
        return GetType();
    }
}
