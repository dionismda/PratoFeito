using Architecture.Infrastructure.Extensions;

namespace Architecture.Infrastructure.Abstracts;

public abstract class EntityTypeMap<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : Entity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder
            .HasKey(e => e.Id);

        builder
            .Property(e => e.Id)
            .HasColumnName(typeof(TEntity).Name.ToSnakeCase() + "_id")
            .HasColumnType("uuid")
            .IsRequired()
            .IdentifierConversion();
    }
}
