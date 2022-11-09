namespace _Shared.Domain.Entities;

public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTime Created { get; private set; }

    public string? CreatedBy { get; private set; }

    public DateTime? LastModified { get; private set; }

    public string? LastModifiedBy { get; private set; }

    public BaseAuditableEntity() : base()
    {
        Created = DateTime.UtcNow.ToUniversalTime();
    }

    public void SetCreatedby(string createdBy)
    {
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
