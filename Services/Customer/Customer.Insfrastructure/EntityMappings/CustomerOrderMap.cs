namespace Customer.Insfrastructure.EntityMappings;

public class CustomerOrderMap : BaseEntityMap<CustomerOrderEntity>
{
    public CustomerOrderMap(Guid tenantId) : base(tenantId)
    {
    }

    public override void Configure(EntityTypeBuilder<CustomerOrderEntity> builder)
    {
        base.Configure(builder);

        builder
            .HasOne(co => co.Customer)
            .WithMany(c => c.CustomerOrders)
            .IsRequired();

        builder
            .OwnsOne(c => c.OrderTotal, i =>
            {
                i.Property(p => p.Amount)
                 .HasColumnName("amount")
                 .HasPrecision(10, 4)
                 .IsRequired();
            });

        builder
        .Property(c => c.OrderState)
        .IsRequired();

    }
}
