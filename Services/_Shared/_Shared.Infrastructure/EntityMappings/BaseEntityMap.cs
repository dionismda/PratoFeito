namespace _Shared.Infrastructure.EntityMappings;

public abstract class BaseEntityMap<TBaseModel> : IEntityTypeConfiguration<TBaseModel>
    where TBaseModel : BaseEntity
{
    private readonly Guid _tenantId;
    public BaseEntityMap(Guid tenantId)
    {
        _tenantId = tenantId;
    }

    public virtual void Configure(EntityTypeBuilder<TBaseModel> builder)
    {
        builder
            .HasKey(e => e.Id);

        builder
            .HasQueryFilter(e => e.TenantId == _tenantId);

        builder
            .Property(e => e.Id)
            .HasColumnName(typeof(TBaseModel).Name.Replace("Entity", "").ToSnakeCase() + "_id")
            .HasColumnType("uuid")
            .IsRequired();

        builder
            .Property(e => e.TenantId)
            .HasColumnType("uuid")
            .IsRequired();

        builder
            .Ignore(e => e.DomainEvents);
    }
}
