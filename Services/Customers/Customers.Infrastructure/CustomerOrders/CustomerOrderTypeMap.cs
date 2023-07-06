namespace Customers.Infrastructure.CustomerOrders;

public sealed class CustomerOrderTypeMap : AggregateTypeMap<CustomerOrder>
{
    public override void Configure(EntityTypeBuilder<CustomerOrder> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.CustomerId)
            .IsRequired()
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("customer_id")
            .IdentifierConversion();

        builder.HasOne<Customer>()
               .WithMany()
               .IsRequired()
               .HasForeignKey(e => e.CustomerId);

        builder
            .Property(x => x.OrderTotal)
            .IsRequired()
            .MoneyConversion();
    }
}
