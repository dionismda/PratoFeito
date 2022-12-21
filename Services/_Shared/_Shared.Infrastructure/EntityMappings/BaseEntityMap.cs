namespace _Shared.Infrastructure.EntityMappings;

public abstract class BaseEntityMap<TBaseModel> : IEntityTypeConfiguration<TBaseModel>
    where TBaseModel : BaseEntity
{
    private readonly IDbContextConfig _dbContextConfig;
    public BaseEntityMap(IDbContextConfig dbContextConfig)
    {
        _dbContextConfig = dbContextConfig;
    }

    public virtual void Configure(EntityTypeBuilder<TBaseModel> builder)
    {
        builder
            .HasKey(e => e.Id);

        builder
            .HasQueryFilter(e => e.TenantId == _dbContextConfig.TenantId);

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
