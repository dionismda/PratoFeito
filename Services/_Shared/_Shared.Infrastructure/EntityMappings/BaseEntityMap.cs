namespace _Shared.Infrastructure.EntityMapping;

public abstract class BaseEntityMap<TBaseModel> : IEntityTypeConfiguration<TBaseModel> 
    where TBaseModel : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TBaseModel> builder)
    {
        builder
            .HasKey(e => e.Id);

        builder
            .Property(e => e.Id)
            .HasColumnName(typeof(TBaseModel).Name.Replace("Entity", "").ToSnakeCase() + "_id")
            .HasColumnType("uuid")
            .IsRequired();

        builder
            .Ignore(e => e.DomainEvents);
    }
}
