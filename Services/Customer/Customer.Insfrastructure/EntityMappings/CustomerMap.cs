namespace Customer.Insfrastructure.EntityMappings;

public class CustomerMap : BaseEntityMap<CustomerEntity>
{
    public override void Configure(EntityTypeBuilder<CustomerEntity> builder)
    {
        base.Configure(builder);

        builder
            .OwnsOne(x => x.Name, i =>
            {
                i.Property(p => p.FirstName)
                 .HasColumnName("first_name") 
                 .HasMaxLength(120)
                 .IsRequired();

                i.Property(p => p.LastName)
                 .HasColumnName("last_name")
                 .HasMaxLength(120)
                 .IsRequired();
            });

        builder
            .OwnsOne(x => x.OrderLimit, i =>
            {
                i.Property(p => p.Amount)
                 .HasColumnName("amount")
                 .HasPrecision(10, 4)
                 .IsRequired();
            });        
    }
}
