namespace _Shared.Domain.Entities;

public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTime Created { get; private set; }

    public string CreatedBy { get; private set; }

    public DateTime LastModified { get; private set; }

    public string? LastModifiedBy { get; private set; }

    [JsonConstructor]
    protected BaseAuditableEntity() { }

    public BaseAuditableEntity(string createdBy) : base()
    {
        CreatedBy = createdBy;
        Created = DateTime.UtcNow.ToUniversalTime();        
        LastModified = DateTime.UtcNow.ToUniversalTime();
    }

    public BaseAuditableEntity(DateTime created, string createdBy, Guid id) : base(id)
    {
        Created = created;
        CreatedBy = createdBy;
    }

    public void SetLastModified()
    {
        LastModified = DateTime.UtcNow.ToUniversalTime();
    }

    public void SetLastModifiedBy(string lastModifiedBy)
    {
        LastModifiedBy = lastModifiedBy;
    }

}
