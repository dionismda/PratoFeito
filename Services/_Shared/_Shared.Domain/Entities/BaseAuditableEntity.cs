namespace _Shared.Domain.Entities;

public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTime Created { get; private set; }

    public DateTime? LastModified { get; private set; }

    protected BaseAuditableEntity() : base()
    {
        Created = DateTime.UtcNow.ToUniversalTime();        
        LastModified = null;
    }

    public void ChangeLastModified()
    {
        LastModified = DateTime.UtcNow.ToUniversalTime();
    }
}
